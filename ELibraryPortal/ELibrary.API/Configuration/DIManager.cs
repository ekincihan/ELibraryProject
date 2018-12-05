using Autofac;
using Autofac.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.API.Configuration
{
    public class DIManager
    {
        private static volatile DIManager instance;
        private static object syncRoot = new Object();
        private ContainerBuilder _builder;
        private IContainer _container;
        private AutofacServiceProvider _provider;

        public ContainerBuilder Builder
        {
            get { return _builder; }
            set
            {
                _builder = value;
            }
        }

        public IContainer Container
        {
            get { return _container; }
            set
            {
                _container = value;
            }
        }

        public AutofacServiceProvider Provider
        {
            get { return _provider; }
            set
            {
                _provider = value;
            }
        }

        private DIManager()
        {
            Builder = new ContainerBuilder();
        }

        public static DIManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new DIManager();
                    }
                }

                return instance;
            }
        }

        public void Build()
        {
            Container = Builder.Build();
            Provider = new AutofacServiceProvider(DIManager.Instance.Container);
        }

        public void Register<T>()
        {
            var updater = new ContainerBuilder();
            updater.RegisterType<T>();
        }

    }
}
