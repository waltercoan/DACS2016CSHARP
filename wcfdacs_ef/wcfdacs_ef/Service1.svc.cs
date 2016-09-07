using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PersistenceProject
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public void AddTabelaPreco(TabelaPreco tp)
        {
            using (var context = new WebServiceDBContext())
            {
                foreach (Product p in tp.producs){
                    context.Produtcs.Attach(p);
                    context.Entry(p).State = EntityState.Unchanged;
                }
                
                context.TabelaPrecos.Add(tp);
                context.SaveChanges();
            }
        }

        public Product GetProduct(long id)
        {
            Product prod = null;

            using(var context = new WebServiceDBContext())
            {
                prod = context.Produtcs.Find(id);
            }
            
            return prod;
        }
        public void AddProduct(Product p)
        {
            using (var context = new WebServiceDBContext())
            {
                context.Produtcs.Add(p);
                context.SaveChanges();
            }
        }

        public ICollection<Product> GetAll()
        {
            using (var context = new WebServiceDBContext())
            {
                return context.Produtcs.ToList();
            }
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
