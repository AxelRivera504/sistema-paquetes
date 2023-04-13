﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paqueteria.DataAccess.Repositories.Paq;
using Paqueteria.Entities.Entities;

namespace Paqueteria.BusinessLogic.Services
{
   public class PaqueteriaServices
    {

        private readonly EnviosPorPaqueteRepository _enviosPorPaquetesRepository;
        private readonly EnviosRepository _enviosRepository;

        public PaqueteriaServices(EnviosPorPaqueteRepository enviosPorPaqueteRepository, EnviosRepository enviosRepository)
        {
            _enviosPorPaquetesRepository = enviosPorPaqueteRepository;
            _enviosRepository = enviosRepository;
        }


        #region Envios Por Paquete

        public ServiceResult BuscarPaquetes(int id)
        {
            var result = new ServiceResult();

            try
            {
                var paquetes = _enviosPorPaquetesRepository.Find(id);
                if (paquetes != null)
                {
                    return result.Ok(paquetes);
                }
                else
                {
                    return result.Error($"No se encontró los paquetes con ID {id}");
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }


        public ServiceResult InsertarEnvioPorPaquete(tblEnviosPorPaquetes item)
        {
            var result = new ServiceResult();
            try
            {               
                    var map = _enviosPorPaquetesRepository.Insert(item);
                    if (map.CodeStatus > 0)
                    {
                        return result.Ok(map);
                    }
                    else
                    {
                        map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de Consulta" : map.MessageStatus;
                        return result.Error(map);
                    }           
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarEnvioPorPaquete(tblEnviosPorPaquetes item)
        {
            var result = new ServiceResult();
            try
            {

                var map = _enviosPorPaquetesRepository.Delete(item);
                if (map.CodeStatus > 0)
                {
                    return result.Ok(map);
                }
                else
                {
                    map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de Consulta" : map.MessageStatus;
                    return result.Error(map);
                }

            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }



        #endregion


        #region Envios

        public IEnumerable<WV_tblEnvios> ListarEnvios()
        {
            var result = new ServiceResult();


            var list = _enviosRepository.List();
            return list;

        }

        public ServiceResult InsertarEnvio(tblEnvios item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _enviosRepository.Insert(item);
                if (map.CodeStatus > 0)
                {
                    return result.Ok(map);
                }
                else
                {
                    map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de Consulta" : map.MessageStatus;
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }

        public ServiceResult EditarEnvio(tblEnvios item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _enviosRepository.Update(item);
                if (map.CodeStatus > 0)
                {
                    return result.Ok(map);
                }
                else
                {
                    map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de Consulta" : map.MessageStatus;
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarEnvio(tblEnvios item)
        {
            var result = new ServiceResult();
            try
            {
                var map = _enviosRepository.Delete(item);
                if (map.CodeStatus > 0)
                {
                    return result.Ok(map);
                }
                else
                {
                    map.MessageStatus = (map.CodeStatus == 0) ? "401 Error de Consulta" : map.MessageStatus;
                    return result.Error(map);
                }
            }
            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }


        #endregion




    }
}
