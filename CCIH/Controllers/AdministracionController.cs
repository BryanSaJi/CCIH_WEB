
using CCIH.Entities.Administracion;
using CCIH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Windows.Media.Media3D;

namespace CCIH.Controllers
{

    public class AdministracionController : Controller
    {
        RolModel modelRol = new RolModel();
        EstatusModel modelEstatus = new EstatusModel();
        ClienteModel modelCliente = new ClienteModel();
        CursosModel modelCurso = new CursosModel();
        ModalidadModel modelModalidad = new ModalidadModel();
        NivelModel modelNivel = new NivelModel();
        HorarioModel modelHorario = new HorarioModel();
        GrupoModel modelGrupo = new GrupoModel();
        MatriculaModel modelMatricula = new MatriculaModel();

        public ActionResult Inicio()
        {
            var datosPreMatricula = modelMatricula.ConsultarPreMatricula();
            var datosMatriculasHoy = modelMatricula.ConsultarMatriculasHoy();
            

            decimal total = 0;
            foreach (var item in datosMatriculasHoy)
            {
                total += item.Monto;
            }

            Session["PreMatriculaPendiente"] = datosPreMatricula.Count;
            Session["MatriculaHoy"] = datosMatriculasHoy.Count;
            Session["TotalMatriculaHoy"] = total;

            return View();
        }

        public ActionResult Cliente()
        {

            var roles = modelRol.ConsultarRolesListarRolesScrollDown();
            var ComboRoles = new List<SelectListItem>();
            foreach (var item in roles)
            {
                ComboRoles.Add(new SelectListItem
                {
                    Text = item.Nombre,
                    Value = item.IdRol.ToString()
                });
            }
            ViewBag.Roles = ComboRoles;

            var estatus = modelEstatus.ConsultarEstatusListarRolesScrollDown();
            var ComboEstatus = new List<SelectListItem>();
            foreach (var item in estatus)
            {
                ComboEstatus.Add(new SelectListItem
                {
                    Text = item.Nombre,
                    Value = item.IdEstatus.ToString()
                });
            }
            ViewBag.Estatus = ComboEstatus;


            return View();
        }



        public ActionResult CrearMatricula(ClienteEnt ent)
        {
            try
            {
                var resp = modelCliente.RegistrarCliente(ent);
                var datos = ent;
                Session["CedulaCliente"] = datos.Cedula;

                if (resp > 0)
                {
                    //Estatus
                    var estatus = modelEstatus.ConsultarEstatusListarRolesScrollDown();
                    var ComboEstatus = new List<SelectListItem>();
                    foreach (var item in estatus)
                    {
                        ComboEstatus.Add(new SelectListItem
                        {
                            Text = item.Nombre,
                            Value = item.IdEstatus.ToString()
                        });
                    }
                    //Crusos
                    var crusos = modelCurso.ConsultarCrusosListarRolesScrollDown();
                    var ComboCruso = new List<SelectListItem>();
                    foreach (var item in crusos)
                    {
                        ComboCruso.Add(new SelectListItem
                        {
                            Text = item.Nombre,
                            Value = item.IdCurso.ToString()
                        });
                    }
                    //Modalidad
                    var modalidad = modelModalidad.ConsultarModalidadListarRolesScrollDown();
                    var ComboModalidad = new List<SelectListItem>();
                    foreach (var item in modalidad)
                    {
                        ComboModalidad.Add(new SelectListItem
                        {
                            Text = item.Nombre,
                            Value = item.IdModalidad.ToString()
                        });
                    }
                    //Nivel
                    var nivel = modelNivel.ConsultarNivelListarRolesScrollDown();
                    var ComboNivel = new List<SelectListItem>();
                    foreach (var item in nivel)
                    {
                        ComboNivel.Add(new SelectListItem
                        {
                            Text = item.Nombre,
                            Value = item.IdNivelCurso.ToString()
                        });
                    }
                    //Horario
                    var horario = modelHorario.ConsultarHorarioListarRolesScrollDown();
                    var ComboHorario = new List<SelectListItem>();
                    foreach (var item in horario)
                    {
                        ComboHorario.Add(new SelectListItem
                        {
                            Text = item.Dia,
                            Value = item.IdHorario.ToString()
                        });
                    }
                    //Grupo
                    var grupo = modelGrupo.ConsultarGrupoListarRolesScrollDown();
                    var ComboGrupo = new List<SelectListItem>();
                    foreach (var item in grupo)
                    {
                        ComboGrupo.Add(new SelectListItem
                        {
                            Text = item.IdGrupo.ToString(),
                            Value = item.IdGrupo.ToString()
                        });
                    }


                    ViewBag.Grupo = ComboGrupo;
                    ViewBag.Horario = ComboHorario;
                    ViewBag.Nivel = ComboNivel;
                    ViewBag.Modalidad = ComboModalidad;
                    ViewBag.Cruso = ComboCruso;
                    ViewBag.Estatus = ComboEstatus;
                    return View();

                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }


        }




        public ActionResult ConsultarMatriculas()
        {
            var datos = modelMatricula.ConsultarMatriculas();

            return View(datos);

        }
    }
}

