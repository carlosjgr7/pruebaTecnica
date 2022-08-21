using System;
using pruebatecnica.Models;
using Xamarin.Forms;

namespace pruebatecnica.Selector
{
    public class SelectorTemplate : DataTemplateSelector
    {

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var collection = container as CollectionView;
            if (container != null)
            {
                var product = item as Root;
                if (product.title.Contains("cadenaparacolocarelskeletonviewbien"))
                    return (DataTemplate)collection.Resources["loadingProducts"];

                if (product.rating.rate >= 4)
                   return (DataTemplate)collection.Resources["productWithStar"];
                

                return (DataTemplate)collection.Resources["productWithOutStar"];
            }
            return null;
        }
    }
}

