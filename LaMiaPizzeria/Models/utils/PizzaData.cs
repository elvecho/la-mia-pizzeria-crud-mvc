using Microsoft.AspNetCore.Mvc;

namespace LaMiaPizzeria.Models.utils
{
    public static class PizzaData
    {
        public static List<Pizza> pizze;
        public static List<Pizza> GetPizza()
        {
            if(PizzaData.pizze != null)
            {
                return PizzaData.pizze;
            }
            List<Pizza> NuovaListaPizze = new List<Pizza>();

            Pizza pizza1 = new Pizza(1, 5, "pizza margherita", "pomodoro mozzarella", "/img/margherita.jpg");
            NuovaListaPizze.Add(pizza1);
            Pizza pizza2 = new Pizza(2, 6, "pizza 4 formaggi", "pomodoro mozzarella formaggi misti", "/img/4formaggi.jpg");
            NuovaListaPizze.Add(pizza2);
            Pizza pizza3 = new Pizza(3, 6, "Pizza con patatine", "pomodoro mozzarella patatine", "/img/images.jpg");
            NuovaListaPizze.Add(pizza3);
            Pizza pizza4 = new Pizza(4, 7, "pizza frutti di mare", "pomodoro mozzarella frutti di mare", "/img/frutti di mare.jpg");
            NuovaListaPizze.Add(pizza4);
            Pizza pizza5 = new Pizza(4, 7, "pizza capricciosa", "pomodoro mozzarella prosciutto olive funghi capperi e carciofini ", "/img/capricciosa.jpg");
            NuovaListaPizze.Add(pizza5);
            Pizza pizza6 = new Pizza(5, 7, "Speck e Zola", "pomodoro mozzarella speck e zola", "/img/download.jpg");
            NuovaListaPizze.Add(pizza6);
            PizzaData.pizze = NuovaListaPizze;

            return PizzaData.pizze;
        }
    }

}