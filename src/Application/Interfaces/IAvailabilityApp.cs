﻿using Domain;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces;
public interface IAvailabilityApp
{
    Task<bool> ScheduleAvailability(UserAvailability useravailability);

    Task<List<UserAvailability>> GetUserAvailabilities();

    Task<List<Availability>> GetAvailabilitybyTime(DateTime startTime, DateTime endTime);

    Task<List<AvailabilitySummaryDTO>> GetAvailabilitySummary();


}
