using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Extras.Models;
using Extras.Models.Request;
using Extras.Models.Respuesta;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Extras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class turnosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (planillaExtrasContext db = new planillaExtrasContext())
                {
                    var lst = db.Turnos.Where(x => x.Estado == true).ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        public IActionResult Add(turnosRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (planillaExtrasContext db = new planillaExtrasContext())
                {
                    Turno oTurno = new Turno
                    {
                        Codigoth = oModel.codigoth,
                        Dia = oModel.dia,
                        HoraEntrada = oModel.hora_entrada,
                        HoraSalida = oModel.hora_salida,
                        HoraIniDescanso = oModel.hora_ini,
                        HoraFinDescanso = oModel.hora_fin,
                        Observaciones = oModel.observaciones
                    };
                    db.Turnos.Add(oTurno);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPut]
        public IActionResult Edit(turnosRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (planillaExtrasContext db = new planillaExtrasContext())
                {
                    Turno oTurno = db.Turnos.Find(oModel.id);
                    oTurno.Codigoth = oModel.codigoth;
                    oTurno.Dia = oModel.dia;
                    oTurno.HoraEntrada = oModel.hora_entrada;
                    oTurno.HoraSalida = oModel.hora_salida;
                    oTurno.HoraIniDescanso = oModel.hora_ini;
                    oTurno.HoraFinDescanso = oModel.hora_fin;
                    oTurno.Observaciones = oModel.observaciones;

                    db.Entry(oTurno).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                //using (LibreriaContext db = new LibreriaContext())
                //{
                //    Editoriale oEditorial = db.Editoriales.Find(Id);
                //    db.Remove(oEditorial);
                //    db.SaveChanges();
                //    oRespuesta.Exito = 1;
                //}

                using (planillaExtrasContext db = new planillaExtrasContext())
                {
                    Turno oTurno = db.Turnos.Find(Id);
                    oTurno.Estado = false;
                    db.Entry(oTurno).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
    }
}
