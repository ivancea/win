using System;
using System.Linq;
using WhatIsNext.Dtos;
using WhatIsNext.Model.Entities;

namespace WhatIsNext.Mappers
{
    public class ConceptToConceptDtoMapping : IClassMapping<Concept, ConceptDto>
    {
        public ConceptDto Map(Concept input)
        {
            return new ConceptDto()
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description,
                DependenciesIds = input.Dependencies.Select(d => d.DependencyId).ToList(),
                GraphId = input.Graph.Id
            };
        }
    }
}