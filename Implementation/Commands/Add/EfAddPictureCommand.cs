using Application.Commands;
using Application.DataTransfer;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Implementation.Validators;
using FluentValidation;

namespace Implementation.Commands
{
    public class EfAddPictureCommand : EfBaseCommand, ICreatePictureCommand
    {
        public EfAddPictureCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 2;

        public string Name => "Add Picture";

        public void Execute(AddPicture request)
        {
            var pic = new Domain.Picture
            {
                src = request.Src,
                alt = request.Alt,
                PostId = request.PostId
            };
            if (Context.Pictures.Any(t => t.src == request.Src))
            {
                throw new EntityAllreadyExists("Picture "+pic.Id);
            }
            Context.Pictures.Add(pic);
            try
            {
                Context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
    }
}
