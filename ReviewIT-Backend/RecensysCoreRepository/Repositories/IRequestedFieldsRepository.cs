﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecensysCoreRepository.DTOs;

namespace RecensysCoreRepository.Repositories
{
    public interface IRequestedFieldsRepository: IDisposable
    {
        IEnumerable<ArticleWithRequestedFieldsDTO> GetAll(int stageId);
        ArticleWithRequestedFieldsDTO Read(int articleId);
    }
}