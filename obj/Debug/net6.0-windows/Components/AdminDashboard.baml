   M S B A M L   `   `   `  ����P  LEmployee_Task_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Employee_Task_Manager.Components Employee_Task_Manager.Components  5      S.clr-namespace:Employee_Task_Manager.Components Employee_Task_Manager.Components  5      5    /Employee_Task_Manager.Components.AdminDashboard   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:Employee_Task_Manager.Components     5      E
components.clr-namespace:Employee_Task_Manager.Components     5      .��5
      � 
�������y�6   �� *ShouldRenderAdmin+  � RowDefinitions  5   
   �� 5      $��80 �6   �� 5      .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      �� 5      �� 5      �� 5      .+�5      �� -   5         ��Name$ 	TaskTitle��5      $��0��5      $��18(�5      $
��Wrap=�5      $
��Bold"�5        $   MaterialDesignHeadline6TextBlock#��[  5!      $��Center=�5"      $��Center=�5#      $��Title��5$      �� 5&      -   5        $ TaskCurrentAssignee��5'      $��1��5(      $��18(�5)      $
��Wrap=�5*      $
��Bold"�5+      #��[  5,      $��Center=�5-      $��Center=�5.      $��Assigneed To��5/      �� 51      -   5        $ TaskCurrentStatus��52      $��2��53      $��18(�54      $
��Wrap=�55      $
��Bold"�56      #��[  57      $��Center=�58      $��Center=�59      $��Current Status��5:      �� 5<      -   5        $ Actions��5=      $��4��5>      $��18(�5?      $
��Wrap=�5@      $
��Bold"�5A      #��[  5B      $��Center=�5C      $��Center=�5D      $��Actions��5E      �� 5G      $��0��5H      $��5��5I      $��Stretch=�5J      $��Bottom=�5K      ���#000000$��2��5M      5O      � 5Q   
   $��1��6   .+�5S      �� $
��Auto=�6   .��5T      �� -   5        $��TaskListItems��5T      ��5U      �� 5V      .R�5W      �  � Orientation$ Vertical=�6(   5X      ��5Z      �� 5[      .R�5\      �� $
��1920��6)   .+�5^   "   4   .Employee_Task_Manager.Components.AdminTaskCard  5_      5`      5b      5c      5d      5e      5f      