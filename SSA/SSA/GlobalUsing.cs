﻿global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.IdentityModel.Tokens;
global using System.IdentityModel.Tokens.Jwt;
global using System.Text;
global using SSA.StartUp;
global using SSA.Interfaces;
global using SSA.Handlers;
global using DataModels.Models;
global using Business.Interface;
global using Business.Manager;
global using SSA.Constants;
global using DataAccess.Interface;
global using DataAccess.Repository;
global using DataAccess.DataContext;
global using AutoMapper;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;