   M S B A M L   `   `   `  ����E  AFlyMessage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:FlyMessage
FlyMessage  5   	       FlyMessage.TcpServer   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $localclr-namespace:FlyMessage  5   	   -   5          � Title$  Server��5	   	   $	��500��6   $	��800��6%   $	��500��61   $	��700��6A   
�������.��5
      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��6* �6   �� 5      $��6* �6   �� 5      $��2* �6    � ColumnDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      $
��1.5* �6   �� 5      $
��0.1* �6   �� 5      $
��1.5* �6   �� 5      $
��0.1* �6   �� 5      $��1* �6   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $
��0.1* �6   �� 5      $��2* �6   �� 5      $
��0.1* �6   .+�5   
   �� -   5         ��Name$ Users��5      $��1��6!   $��1��6.   
�������$��Corbel Light)�6U   $��3��6o   $��23(�6�   �� 5   
   -   5        $
 Logs��5      $��2��6    $��1��6-   
�������$��Corbel Light)�6T   $��3��6n   �� 5       $��Пользователи��6   $��0��6$   $��1��61   $��3��6A   $��Center=�6U    �� TextAlignment$ Center=�6p   $��Corbel Light)�6�   $��30(�6�   �� 5!      -   5        $ first��5!      $��0��6   $��3��6*   $��5��6;   $��5��6K   
�������$��Corbel Light)�6v   $��20(�6�   �� 5"      -   5         ��Name$	 box��5"      $��5��6   $��3��6+   $��Corbel Light)�68   $��3��6R   $��Center=�6f   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Сообщение��6�   $��34��6�   �� 5#   
   -   5         $   MaterialDesignOutlinedDarkButton#��[  5$       � ToolTip$" MaterialDesignOutlinedButton��5%      $��Corbel Light)�5&      $��Отправить��5'      $��9��5)      $��3��5*      
����ح�$��Center=�5-      {�5(      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+	 �� AncestorType
	 Window5-      �� 5.   
   -   5        #��[  5/   	   $" MaterialDesignOutlinedButton��50      $��Corbel Light)�51      $��
Выйти��52      $��1��54      $��3��55      $��3��56      $��Center=�58      {�53      �� *DataContext.ControlsEnabled+ �� *FindAncestor+
	 Window58      59      5:      