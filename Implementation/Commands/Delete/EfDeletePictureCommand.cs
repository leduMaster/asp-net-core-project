using Application.Commands;
using Application.DataTransfer;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using Implementation.Validators;
using FluentValidation;

namespace Implementation.Commands
{
    public class EfDeletePictureCommand : EfBaseCommand, IDeletePictureCommand
    {
       
        public EfDeletePictureCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 13;

        public string Name => "Delete Picture";

        public void Execute(int request)
        {
            var picDto = Context.Pictures.Find(request);

            if (picDto != null)
            {
                try
                {
                    picDto.IsDeleted = true;
                    Context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else throw new EntityNotFoundException(request, typeof(PictureDto));
        }
    }
}
