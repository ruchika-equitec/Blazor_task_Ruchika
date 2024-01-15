﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using BlazorApp1.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorApp1.Models
{
    public partial interface IRuchi_studContextProcedures
    {
        Task<int> DeleteStudAsync(int? StudentID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> RetriveAsync(int? StudentID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<SoftDeletedStudViewResult>> SoftDeletedStudViewAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> SoftDeleteStudAsync(int? StudentID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> StudAddDeleteAsync(int? StudentID, string Name, string EmailID, int? Age, string Skills, string Gender, int? Fees, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> StudDeleteByIdAsync(int? StudentId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<StudViewResult>> StudViewAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<StudViewByIdResult>> StudViewByIdAsync(int? StudentId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<StudViewWithPageSizeResult>> StudViewWithPageSizeAsync(int? PageSize, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> UpdateStudentAsync(int? StudentID, string Name, string EmailID, int? Age, string Skills, int? Fees, string Gender, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
    
}
