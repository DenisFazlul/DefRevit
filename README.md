# DefRevit

Пакет для упрощения разрабоки плагинов под ревит




Добавление кнопок 

UIControlledApplication a;
ButtonBuilder bd = new  ButtonBuilder(a);
bd.CreateButton(new ButtonConfig(typeof(Command))
{
    DisplayName="Button Name",
});

Создание инстанса плагина

ExternalCommandData commandData;
PluginInstance inst=new PluginInstance(commandData);
  
