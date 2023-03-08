global using Microsoft.EntityFrameworkCore;

global using BlazingPizza.Shared.BusinessObjects.Entities;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;

global using System.Reflection;

global using Microsoft.EntityFrameworkCore.Design;

global using BlazingPizza.Backend.BusinessObjects.Interfaces.Common;
global using BlazingPizza.EFCore.Repositories.DataContexts;
global using BlazingPizza.EFCore.Repositories.Mappers;

global using Microsoft.Extensions.DependencyInjection;
global using EFEntities = BlazingPizza.EFCore.Repositories.Entities;
global using BlazingPizza.Shared.BusinessObjects.Dtos;
global using BlazingPizza.Backend.BusinessObjects.ValueObjects.Options;

global using Microsoft.Extensions.Options;
global using BlazingPizza.EFCore.Repositories.Interfaces;
global using BlazingPizza.Shared.BusinessObjects.Aggregates;
global using BlazingPizza.Shared.BusinessObjects.Enums;
global using SharedEntities = BlazingPizza.Shared.BusinessObjects.Entities;
global using SharedValueObjects = BlazingPizza.Shared.BusinessObjects.ValueObjects;
global using SharedAggregates = BlazingPizza.Shared.BusinessObjects.Aggregates;
