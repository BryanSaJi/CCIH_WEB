using CCIH.Entities;
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
    public class MatriculaController : Controller
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

        [HttpPost]
        public ActionResult RegistrarMatricula(MatriculaEnt entidad)
        {
            entidad.Cedula = @Session["CedulaCliente"].ToString();
            try
            {

                var resp = modelMatricula.RegistrarMatricula(entidad);

                if (resp > 0)
                {
                    @Session["CedulaCliente"] = "";
                    return RedirectToAction("ConsultarMatriculasHoy");
                }
                else
                {
                    ViewBag.MsjPantalla = "No se ha podido registrar su información";
                    return View("CrearMatricula");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult ConsultarPreMatricula(PreMatriculaEnt entidad)
        {
            var datos = modelMatricula.ConsultarPreMatricula();
            Session["PreMatriculaPendiente"] = datos.Count;

            
            return View(datos);
        }

        [HttpGet]
        public ActionResult ConsultarMatricula(long i)
        {
            var datos = modelMatricula.ConsultarMatricula(i);

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
            ViewBag.Estatus = ComboEstatus;


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
            ViewBag.Cruso = ComboCruso;


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
            ViewBag.Modalidad = ComboModalidad;

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
            ViewBag.Nivel = ComboNivel;


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
            ViewBag.Horario = ComboHorario;

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

            return View(datos);
        }

        [HttpPost]
        public ActionResult EditarMatricula(MatriculaEnt entidad)
        {
            var resp = modelMatricula.EditarMatricula(entidad);

            if (resp > 0)
                return RedirectToAction("ConsultarMatriculasHoy");
            else
            {
                return View("ConsultarMatriculasHoy");
            }
        }

        [HttpGet]
        public ActionResult ContactoPrematricula(int q)
        {
            PreMatriculaEnt entidad = new PreMatriculaEnt();
            entidad.IdPrematricula = q;

            var resp = modelMatricula.ContactoPrematricula(entidad);

            if (resp > 0)
                return RedirectToAction("ConsultarPreMatricula", "Matricula");
            else
            {
                return View("Index", "Administracion");
            }
        }

        [HttpGet]
        public ActionResult ConsultarMatriculasHoy()
        {
            var datos = modelMatricula.ConsultarMatriculasHoy();
            return View(datos);

        }

    }


}