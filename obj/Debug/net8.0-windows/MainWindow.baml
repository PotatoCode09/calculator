   M S B A M L   `   `   `  ����E  ACalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Calculator
Calculator  5   	       Calculator.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Calculator     5   	     � Title$  
MainWindow��5   	   $	��750��6   $��900         ��6)    � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property	 P� Value
 �� 
TargetName3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   Color   	Direction   Opacity   RenderingBias   ShadowDepth   ShowSidebar �� 
TargetName �� TargetProperty	 W� To g� Duration  HideSidebar��%�  '��       &	  �    &	 <    �� 5   
   " ��6   .�5      ��  � ��$ 95��6&   �� 5       � ��$ 90��6'   �� 5       � ��$ 3,3,3,3q�6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��Part_Background��6�   #��z��6!   $��0q�6U   $ 4��6i   
�������._�5      �� #��z��6/   $��Center=�6b   $��Center=�6   5       5      P� 5       �@J�IsMouseOver$
	 True��6G   . �5   "   �� $
 Part_Background��6F    � ��
 �����6c   �� 5   "    �@J�Effect 5   &     5   *   $ 5Q�6;   $
 Blue��6J   $ 0Q�6W   $	 0.4Q�6e   $ Performance=�6s   $ -4Q�6�   5   #   5      P� 5       � ��$
	 True��6F   . �5    "   �� $
 Part_Background��6F    � ��
 �����6c   �� 5!   "    �@J�Effect 5"   &     5#   *   $ 5Q�6;   $	 Red��6J   $ 0Q�6V   $	 0.8Q�6d   $ Performance=�6r   $ -4Q�6�   5%   #   5&      5(      5*      5+      �� 5-   
   .��5.      W� $ SidebarTransform��6   $ X�5/       050      $ 0:0:0.3D�6%   51      �� 53   
   .��54      W� $ SidebarTransform��6   $ X�55       -20056      $ 0:0:0.3D�6(   57      5:      .��5<      �  � RowDefinitions 5=   
   �� 5>      $
��Auto �6   �� 5?      .+�5B   
    � -   5          �Name$ 	MainFrame��5B        � NavigationUIVisibility$ Hidden=�6#   $��1��6C   �� 5C   
   -   5        $
��Menu��5C      $	��☰��6   $��0��6-   $��30(�6<   $��5,0,5,0q�6L   $
��Left=�6]   $��80��6x    K� ZIndex$ 2��6�   �� 5D   
   -   5        $��CalcType��5D      $��Standard��6!   $��0��65   $��50(�6B   $
��Left=�6P   $��	85,-2,0,2q�6k   �� 5F   
   -   5         ��Name$ HistoryList��5F      $��1��6'   $y�	Collapsed=�64   
�������$	��300��6b   $��Right=�6n   $��0,0,10,0q�6�   �� 5H   
   -   5         ��Name$ SidebarMenu��5H      $	��750��6&   $	��200��63   $��0��5I      $��4��6   $��3��6/   $��Stretch=�5J      $
��Left=�6-   
�������$y�	Collapsed=�5K   #   ._�5N      �� .+�5O      �  5P      �� 5Q      $	��100 �6(   �� 5R      $��20 �6(   5U      �� 5Y      -   5        $��Standard��5Y      $��25(�6,   
���   �
���   �$	��181��6`   6l   �� 5Z      -   5        $��
Scientific��5Z      $��25(�6.   
���   �
���   �$	��181��6c   6o   �� 5[      -   5        $��
Programmer��5[      $��25(�6.   
���   �
���   �$	��181��6c   6o   �� 5\      -	   5        $��Date calculator��5\      $��25(�63   
���   �
���   �$	��181��6g   6s   5]      5`      5b      5c      