   M S B A M L   `   `   `  ����E  AFlyMessage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:FlyMessage
FlyMessage  5   	       FlyMessage.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $localclr-namespace:FlyMessage  5   	     � Title$  
FlyMessage��5	   	   $	��300��6   $	��500��6)   
�������.��5
      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $
��0.1* �6   .+�5   
   �� -   5        $��AddChat��5        $   MaterialDesignOutlinedDarkButton#��[  5       � ToolTip$" MaterialDesignOutlinedButton��5      $��Corbel Light)�5      $&�� Создать новый чат��5      $��1��5      $��2��5      $��2��5"      
����ح�$��Center=�5$      {�5      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType
 Window5$      �� 5%   
   -   5        $��ToChat��5,      #��[  5&      $" MaterialDesignOutlinedButton��5'      $��Corbel Light)�5(      $(��"Подключится к чату��5)      $��4��5+      $��1��5.      $��2��5/      
����ح�$��Center=�51      {�5*      �� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window51      �� 52   
   $��Fly Message��6   $��0��6'   $��38(�64   $��Segoe Script)�6B   $��Center=�6\   $��Center=�6w   $��2��6�   $��1��6�   �� 53   
   -   5         ��Name$
 Name��53      $��1��6    $��1��60   $��Candara Light)�6=   $��Center=�6X   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$$ Введите свое имя��6t   $��2��6�   �� 54   
   -   5        $ IP��54      $��1��6   $��3��6.   $��Candara Light)�6;   $��Center=�6V   $+ %Введите IP адрес чата��6r   $��2��6�   55      56      