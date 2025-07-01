﻿namespace ProgrammingClub.Models
{
    public class PagedResultDto<T>
    {
        public IEnumerable<T> Items { get; set; } = new List<T>();

        public int TotalCount { get; set; }
    }
}
