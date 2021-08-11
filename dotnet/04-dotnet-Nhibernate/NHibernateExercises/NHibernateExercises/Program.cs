﻿using NHibernate;
using NHibernateCore;
using NHibernateExercises.Entities;
using NHibernateExercises.Infrastructure;
using NHibernateExercises.Repositories;
using NHibernateExercises.Services;
using SimpleInjector;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using NHibernate.Validator.Engine;

namespace NHibernateExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Project"].ConnectionString;
            var container = new Container();
            container.RegisterInstance(new ExerciseSessionFactory(connectionString).GetSessionFactory());
            container.Register<IUnitOfWorkProvider, UnitOfWorkProvider>(Lifestyle.Singleton);
            container.Register<IInterceptor, NullInterceptor>(Lifestyle.Singleton);
            container.Register<IProjectRepository, ProjectRepository>(Lifestyle.Singleton);
            container.Register<IProjectService, ProjectService>(Lifestyle.Singleton);
            container.Register<IParameterDefinitionRepository, ParameterDefinitionRepository>(Lifestyle.Singleton);
            container.Register<IParameterService, ParameterService>(Lifestyle.Singleton);

            var projectService = container.GetInstance<IProjectService>();
            var parameterService = container.GetInstance<IParameterService>();
            var numbers = projectService.GetAllProjectNumbers().Distinct().ToList();

            //// Exercise 1: Mapping with chapter 8 - Session & unit of work advance
            //// why the transaction deadlock occurs below with ProcessProjectInParallel ? How will we solve it ?
            //Console.WriteLine("Exercise 1: why the transaction deadlock occurs below with ProcessProjectInParallel ? How will we solve it ?");
            //projectService.ProcessProjectInParallel(numbers);
            //Console.WriteLine("------------------------------------------------------------------------------------------------------------");

            //// Exercise 2 : Mapping with chapter 8 - Concurrent update
            //// why OptimisticVersionException is thrown while there is no row into DB for table ParameterDefinition + ParameterValue ?
            //Console.WriteLine("Exercise 2: why OptimisticVersionException is thrown while there is no row into DB for table ParameterDefinition + ParameterValue ?");
            //try
            //{
            //    parameterService.DeleteAllParameters();
            //    var parameter = new ParameterDefinitionEntity
            //    {
            //        Id = 1,
            //        Name = $"Parameter1",
            //        Type = "Integer",
            //        RowVersion = 1
            //    };
            //    var parameterValue = new ParameterValueEntity
            //    {
            //        Id = 1,
            //        Value = "1",
            //        Year = DateTime.Now.Year,
            //        ParameterDefinition = parameter,
            //        RowVersion = 1
            //    };
            //    parameter.ParameterValues.Add(parameterValue);
            //    parameterService.InsertParameter(parameter);
            //    Console.WriteLine("Insert parameter successful. You passed Exercise 2 !");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Error to process for number : " + ex);
            //}
            //Console.WriteLine("------------------------------------------------------------------------------------------------------------");

            //// Assume : you solved the Exercise 3 and saved the parameter into DB successful 
            //// Exercise 3 : Mapping with chapter 6 - Cascade/Inverse  
            //// Why ParameterValue is not deleted into DB when we clear the list 'ParameterValues' and save into DB ? How do we delete ParameterValue by using Cascade? 
            //Console.WriteLine("Exercise 3: (Cascade)  Why ParameterValue is not deleted into DB when we clear the list 'ParameterValues' and save into DB ? How do we delete ParameterValue by using Cascade? ");
            //var para = parameterService.LoadParameter(1);
            //para.ParameterValues.Clear();
            //parameterService.UpdateParameter(para);
            //para = parameterService.LoadParameter(1);
            //if (para.ParameterValues.Count == 0)
            //{
            //    Console.WriteLine("Delete ParameterValue successful. You passed Exercise 3 !");
            //}
            //else
            //{
            //    Console.WriteLine("ParameterValue is not deleted into DB");
            //}
            //Console.WriteLine("------------------------------------------------------------------------------------------------------------");

            //// Exercise 4: Mapping with chapter 9 - Batch update/delete/insert + chapter 1 - Performance Optimizations
            //// Please improve the performance for two methods CreateAllParameters & DeleteAllParameters 
            //Console.WriteLine("Exercise 4: Please improve the performance for two methods CreateAllParameters & DeleteAllParameters");
            //Stopwatch stopWatch = new Stopwatch();
            //stopWatch.Start();
            //parameterService.CreateAllParameters();
            //stopWatch.Stop();
            //Console.WriteLine($"Create all parameters in {stopWatch.Elapsed.TotalSeconds} seconds");
            //stopWatch.Start();
            //parameterService.DeleteAllParameters();
            //stopWatch.Stop();
            //Console.WriteLine($"Delete all parameters in {stopWatch.Elapsed.TotalSeconds} seconds");
            //Console.WriteLine("------------------------------------------------------------------------------------------------------------");

            // Exercise 5: mapping with chapter 3 - Model inheritance (join) & chapter 2 - Advanced mapping concepts
            // We have Table per class hierarchy, Table per type 
            // please extend table ParameterValue so that it can store for both OutputParameterValue and InputParameterValue
            // The OutputParameterValue will have more column FormatData nvarchar(100) , the InputParameterValue will have the column IsMandatory bit
            // after that, please execute the query on parent type and sub type

            // Notes: on Table per class hierarchy, we will have use 1 table for both input and output
            // For Table per type, we will have 3 table OutputParameterValue, InputParameterValue, ParameterValue


            // Exercise 6: Mapping with chapter 4 - Interceptor / event model on NHibernate
            // implement interceptor
            // We will extend the table Project with new columns CreationDate - UpdateDate
            // Please implement the interceptor so that when we save/update data, it will automatically update for these column CreationDate - UpdateDate


            // Exercise 7: Mapping with chapter 5 - Nhibernate Envers
            // please write query to get all revisions of of project with id = 1
            // and query to get a revisions of projects
            var x = projectService.GetAllProjectAudit();

            // Exercise 8: Mapping with chapter 10 - NHibernate validator
            // please write a custom validator for Project which make sure ModificationDate >= CreationDate
            ValidatorEngine validator = new ValidatorEngine();
            var project = new ProjectEntity()
            {
                Name = new string('*', 255),
            };
            bool isValid = validator.IsValid(project);
        }
    }
}
