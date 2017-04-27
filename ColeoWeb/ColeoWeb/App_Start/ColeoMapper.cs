using AutoMapper;
using ColeoDataLayer.ModelColeo;
using ColeoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ColeoWeb.App_Start
{
    public class ColeoMapper : Profile 
    {
        public ColeoMapper()
        {
            CreateMap<Project, ProjectViewModel>()
                .ForMember(vm => vm.Files, dto => dto.MapFrom(m => m.ProjectFiles))
                .ForMember(vm => vm.NameUserCreated, dto => dto.MapFrom(m => m.AspNetUser.UserName))
                .ForMember(vm => vm.StatusName, dto => dto.MapFrom(m => m.ProjectStatus.Name))
                .ForMember(vm => vm.ParentName, dto => dto.MapFrom(m => m.Project1.Name))
                .ReverseMap();

            CreateMap<ProjectStatus, ProjectStatusViewModel>()
                .ReverseMap();

            CreateMap<ProjectFile, FileViewModel>()
                .ForMember(vm => vm.Id, dto => dto.MapFrom(m => m.IdFile))
                .ForMember(vm => vm.Name, dto => dto.MapFrom(m => m.File.Name))
                .ForMember(vm => vm.LocalName, dto => dto.MapFrom(m => m.File.LocalName))
                .ForMember(vm => vm.Extension, dto => dto.MapFrom(m => m.File.Extension));

            CreateMap<UserProject, UserProjectViewModel>()
                .ForMember(vm => vm.UserId, dto => dto.MapFrom(m => m.IdUser))
                .ForMember(vm => vm.User, dto => dto.MapFrom(m => m.AspNetUser))
                .ReverseMap();

            CreateMap<AspNetUser, UserProjectViewModel>()
                .ForMember(vm => vm.UserId, dto => dto.MapFrom(m => m.Id))
                .ForMember(vm => vm.IsAssigned, dto => dto.UseValue(false))
                .ForMember(vm => vm.User, dto => dto.MapFrom(m => m))
                .ReverseMap();

            CreateMap<AspNetUser, UserViewModel>()
                .ReverseMap();
        }
    }
}