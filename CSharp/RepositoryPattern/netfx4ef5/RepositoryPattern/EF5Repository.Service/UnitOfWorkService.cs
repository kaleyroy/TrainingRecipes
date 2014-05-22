using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

using AutoMapper;
using Repository.Pattern.UnitOfWork;
using Repository.Pattern.Repositories;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.EF5;
using EF5Repository.Data;
using EF5Repository.Data.Repositories;

namespace EF5Repository.Service
{
    public abstract class UnitOfWorkService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected IUnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }

        protected IEnumerable<TDataObject> PerformCreateObjects<TDataObject, TEntity>(
            IEnumerable<TDataObject> dataObjects,
            IRepository<TEntity> repository,
            Action<TDataObject> processDataObject = null,
            Action<TEntity> processEntity = null) where TDataObject : DataObject where TEntity : EntityBase
        {
            if (dataObjects == null)
                throw new ArgumentNullException("dataObjects");
            if (repository == null)
                throw new ArgumentNullException("repository");

            List<TDataObject> result = new List<TDataObject>();

            if (dataObjects.Count() > 0)
            {
                List<TEntity> entities = new List<TEntity>();
                foreach (var dataObject in dataObjects)
                {
                    if (processDataObject != null)
                        processDataObject(dataObject);
                    var entity = Mapper.Map<TDataObject, TEntity>(dataObject);
                    if (processEntity != null)
                        processEntity(entity);
                    entities.Add(entity);
                }

                repository.InsertRange(entities);
                _unitOfWork.SaveChanges();

                entities.ForEach(e => result.Add(Mapper.Map<TEntity, TDataObject>(e)));
            }

            return result;
        }

        protected IEnumerable<TDataObject> PerformUpdateObjects<TDataObject,TEntity>(
            IEnumerable<DataObject> dataObjects,
            IRepository<TEntity> repository) where TDataObject : DataObject where TEntity : EntityBase
        {
            if (dataObjects == null)
                throw new ArgumentNullException("dataObjects");
            if (repository == null)
                throw new ArgumentNullException("repository");

            List<TDataObject> result = new List<TDataObject>();

            if (dataObjects.Count() > 0)
            {
                foreach (var dataObject in dataObjects)
                {             
                    var entity = repository.Find(dataObject.ID);
                    if (entity == null)
                        throw new ArgumentNullException("entity");

                    var dbContext = (repository as IEFRepository<TEntity>).Context;
                    var attachedEntry = dbContext.Entry<EntityBase>(entity);
                    attachedEntry.CurrentValues.SetValues(dataObject);
                    entity.ObjectState = ObjectState.Modified;
                   
                    result.Add(Mapper.Map<TEntity, TDataObject>(entity));
                }

                _unitOfWork.SaveChanges();
            }
            return result;
        }

        protected IEnumerable<TDataObject> PerformUpdateObjects<TDataObject, TEntity>(
            IEnumerable<TDataObject> dataObjects,
            IRepository<TEntity> repository,
            Action<TEntity, TDataObject> fieldUpdateConfig) where TDataObject : DataObject where TEntity : EntityBase
        {
            if (dataObjects == null)
                throw new ArgumentNullException("dataObjects");
            if (repository == null)
                throw new ArgumentNullException("repository");
            if (fieldUpdateConfig == null)
                throw new ArgumentNullException("fieldUpdateConfig");

            List<TDataObject> result = new List<TDataObject>();

            if (dataObjects.Count() > 0)
            {
                List<TEntity> entities = new List<TEntity>();
                foreach (var dataObject in dataObjects)
                {
                    var entity = repository.Find(dataObject.ID);
                    fieldUpdateConfig(entity, dataObject);

                    entities.Add(entity);         
                }

                repository.UpdateRange(entities);
                _unitOfWork.SaveChanges();

                entities.ForEach(e => result.Add(Mapper.Map<TEntity, TDataObject>(e)));             
            }

            return result;
        }

        protected IEnumerable<TDataObject> PerformRemoveObjects<TDataObject, TEntity>(
            IEnumerable<TDataObject> dataObjects,
            IRepository<TEntity> repository, 
            Action<TDataObject> preDelete = null, 
            Action<TDataObject> postDelete = null) where TDataObject : DataObject where TEntity : EntityBase
        {
            if (dataObjects == null)
                throw new ArgumentNullException("dataObjects");
            if (repository == null)
                throw new ArgumentNullException("repository");

            List<TDataObject> result = new List<TDataObject>();
            if (dataObjects.Count() > 0)
            {
                List<TEntity> entities = new List<TEntity>();
                foreach (var dataObject in dataObjects)
                {
                    if (preDelete != null)
                        preDelete(dataObject);

                    var entity = repository.Find(dataObject.ID);
                    entities.Add(entity);

                    if (postDelete != null)
                        postDelete(dataObject);
                }

                repository.DeleteRange(entities);
                _unitOfWork.SaveChanges();

                entities.ForEach(e => Mapper.Map<TEntity, TDataObject>(e));
            }

            return result;
        }
    }
}
