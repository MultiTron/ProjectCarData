﻿using PCD.Infrastructure.DTOs;

namespace PCD.ApplicationServices.Messaging.Response;

public class ListResponse<T> : BaseResponse where T : BaseViewModel
{
    public List<T> Content { get; set; }

    public ListResponse(List<T> content)
    {
        Content = content;
    }
    public ListResponse(StatusCode status = StatusCode.Success) : base(status)
    {
        Content = new List<T>();
    }
}
