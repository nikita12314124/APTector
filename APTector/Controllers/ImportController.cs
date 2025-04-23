using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using APTector.DTOs;
using APTector.Data;
using APTector.Models; // ваши EF Core модели
using System.Linq;

namespace APTector.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImportController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ImportController(AppDbContext db)
        {
            _db = db;
        }

        [HttpPost("upload")]
        public IActionResult Upload([FromBody] JsonElement jsonData)
        {
            try
            {
                // Десериализуем JSON в объект MatrixDTO
                var matrixDTO = JsonSerializer.Deserialize<MatrixDTO>(jsonData.ToString(), new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (matrixDTO == null)
                    return BadRequest("Неверный формат JSON.");

                // 1. Сохранение матрицы
                var matrix = _db.Matrices.FirstOrDefault(m => m.MatrixName == matrixDTO.MatrixName);
                if (matrix == null)
                {
                    matrix = new Matrix { MatrixName = matrixDTO.MatrixName, Tactics = new List<Tactic>() };
                    _db.Matrices.Add(matrix);
                    _db.SaveChanges();
                }

                // 2. Обработка тактик и техник
                foreach (var tacticDto in matrixDTO.Tactics)
                {
                    // Ищем тактику по ID или Name
                    var tactic = _db.Tactics.FirstOrDefault(t => t.Id == tacticDto.Id || t.Name == tacticDto.Name);
                    if (tactic == null)
                    {
                        tactic = new Tactic { Id = tacticDto.Id, Name = tacticDto.Name, Techniques = new List<Technique>(), MatrixId = matrix.Id };
                        _db.Tactics.Add(tactic);
                        _db.SaveChanges();
                    }

                    foreach (var techniqueDto in tacticDto.Techniques)
                    {
                        var technique = _db.Techniques.FirstOrDefault(te => te.Id == techniqueDto.Id || te.Name == techniqueDto.Name);
                        if (technique == null)
                        {
                            technique = new Technique { Id = techniqueDto.Id, Name = techniqueDto.Name, TacticId = tactic.Id, Procedures = new List<Procedure>() };
                            _db.Techniques.Add(technique);
                            _db.SaveChanges();
                        }

                        // 3. Обработка процедур
                        foreach (var procDto in techniqueDto.Procedures)
                        {
                            var procedure = _db.Procedures.FirstOrDefault(p => p.Id == procDto.Id || p.Name == procDto.Name);
                            if (procedure == null)
                            {
                                procedure = new Procedure { Id = procDto.Id, Name = procDto.Name, TechniqueId = technique.Id };
                                _db.Procedures.Add(procedure);
                                _db.SaveChanges();
                            }

                            // 4. Связывание процедуры с APT-группами через расширенную таблицу
                            foreach (var aptDto in procDto.AptGroups)
                            {
                                // Поиск или создание APT-группы
                                var aptGroup = _db.APTGroups.FirstOrDefault(a => a.Name == aptDto.GroupName);
                                if (aptGroup == null)
                                {
                                    aptGroup = new APTGroup { Name = aptDto.GroupName, IsFinancial = aptDto.IsFinancial };
                                    _db.APTGroups.Add(aptGroup);
                                    _db.SaveChanges();
                                }

                                // Здесь нужно добавить запись в расширенную таблицу связей с метриками.
                                // Предположим, у вас есть сущность APTGroupProcedure:
                                var existingLink = _db.APTGroupProcedures
                                    .FirstOrDefault(link => link.APTGroupId == aptGroup.Id && link.ProcedureId == procedure.Id);
                                if (existingLink == null)
                                {
                                    var link = new APTGroupProcedure
                                    {
                                        APTGroupId = aptGroup.Id,
                                        ProcedureId = procedure.Id,
                                        Probability = aptDto.Metrics.Probability,
                                        Criticality = aptDto.Metrics.Criticality,
                                        BusinessImpact = aptDto.Metrics.BusinessImpact
                                    };
                                    _db.APTGroupProcedures.Add(link);
                                    _db.SaveChanges();
                                }
                            }
                        }
                    }
                }

                return Ok("Данные успешно импортированы.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ошибка импорта: {ex.Message}");
            }
        }
    }
}
