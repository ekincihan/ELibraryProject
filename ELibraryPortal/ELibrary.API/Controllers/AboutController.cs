using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ELibrary.API.Controllers
{
    [Route("api/About")]
    public class AboutController : Controller
    {
        //[HttpGet]
        //[Route("List")]
        //public async Task<Response<List<TagModel>>> AsyncGet()
        //{
        //    Response<List<TagModel>> tagResponse = new Response<List<TagModel>>();
        //    List<Tag> entityList = await _tag.GetListAsync(x => x.IsActive == true);
        //    tagResponse.Value = _mapper.Map<List<TagModel>>(entityList);
        //    return tagResponse;
        //}

        //[HttpPost]
        //[Route("Save")]
        //public async Task<Response<TagModel>> Post([FromBody]TagModel model)
        //{
        //    Response<TagModel> tagResponseModel = new Response<TagModel>();

        //    try
        //    {
        //        Tag entity = _mapper.Map<Tag>(model);
        //        entity = await (model.Id != Guid.Empty ? _tag.UpdateAsync(entity) : _tag.AddAsync(entity));
        //        tagResponseModel.Value = _mapper.Map<TagModel>(entity);
        //        tagResponseModel.IsSuccess = true;

        //    }
        //    catch (Exception e)
        //    {

        //        tagResponseModel.Exception = e;
        //        tagResponseModel.IsSuccess = false;
        //    }

        //    return tagResponseModel;
        //}

    }
}
