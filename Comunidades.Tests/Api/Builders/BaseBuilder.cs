﻿using Bogus;

namespace Comunidades.Tests.Api.Builders
{
    /// <summary>
    /// Representa a classe base para geração de dados falsos.
    /// </summary>    
    public abstract class BaseBuilder<T> where T : class
    {
        /// <summary>Constante que define a localização para português do Brasil.</summary>
        protected const string PT_BR = "pt_BR";
        /// <summary>Constante que define a localização para o inglês.</summary>
        protected const string EN = "en";

        /// <summary>Obtém o objeto Faker para geração de dados.</summary>
        protected Faker FakeBuilder { get; set; }

        /// <summary>Obtém ou define a lista de entidades a serem criadas com o método Build().</summary>
        protected List<T> Entities { get; set; }

        /// <summary>
        /// Cria uma nova instância de BaseBuilder.
        /// </summary>
        protected BaseBuilder(string locale = PT_BR)
        {
            FakeBuilder = new Faker(locale);
            Entities = new List<T>();
        }

        /// <summary>
        /// Obtém uma entidade.
        /// </summary>
        public T? Get() 
            => Entities.FirstOrDefault();

        /// <summary>
        /// Obtém uma lista de entidades.
        /// </summary>
        public List<T> GetList()
            => Entities;

        /// <summary>
        /// Retorna uma instância da classe com entidades definidas.
        /// </summary>
        /// <param name="numberOfItems">Define o número de entidades a serem criadas.</param>
        /// <returns></returns>
        public abstract BaseBuilder<T> Default(int numberOfItems = 1);

        /// <summary>
        /// Obtém um objeto Person com a localicação de FakerBuilder.
        /// </summary>
        protected Person NewPerson() => new(locale: FakeBuilder.Locale);
    }
}
