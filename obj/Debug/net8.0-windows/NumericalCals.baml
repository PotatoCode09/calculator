   M S B A M L   `   `   `  ����E  ACalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Calculator
Calculator  5          Calculator.NumericalCals   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Calculator     5        N� Title$  NumericalCals��5	       � 	Resources 5
       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property	 P� Value
 �� 
TargetName3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   Color   	Direction   Opacity   RenderingBias   ShadowDepth��%�  '��       �� 5   
   " ��6   .�5      ��  � ��$ 95��6&   �� 5       � ��$ 90��6'   �� 5       � ��$ 3,3,3,3q�6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��Part_Background��6�   #��z��6!   $��0q�6U   $ 4��6i   
�������._�5      �� #��z��6/   $��Center=�6b   $��Center=�6   5       5      P� 5       �@J�IsMouseOver$
	 True��6G   . �5   "   �� $
 Part_Background��6F    � ��
 �����6c   �� 5   "    �@J�Effect 5   &     5   *   $ 5Q�6;   $
 Blue��6J   $ 0Q�6W   $	 0.4Q�6e   $ Performance=�6s   $ -4Q�6�   5   #   5      P� 5       � ��$
	 True��6F   . �5   "   �� $
 Part_Background��6F    � ��
 �����6c   �� 5    "    �@J�Effect 5!   &     5"   *   $ 5Q�6;   $	 Red��6J   $ 0Q�6V   $	 0.8Q�6d   $ Performance=�6r   $ -4Q�6�   5$   #   5%      5'      5)      5*      5,      .��5-      �  � RowDefinitions 5.   
   �� 50      $��45 �6   �� 51      $	��110 �6   �� 52      $��* �6    � ColumnDefinitions 55   
   �� 56      $��* �6   �� 57      $��* �6   �� 58      $��* �6   �� 59      $��* �6   �� 5:      $��* �6   �� 5;      $��* �6   �� 5<      $��* �6   �� 5=      $��* �6   �� 5>      $��* �6   �� 5?      $��* �6   .+�5B   
   �� -   5         ��Name$ 
Expression��5B      $�� ��6(   $��0��61   $��30(�6>    �� TextAlignment$ Right=�6L   $��10��6b   �� 5C   
   -   5         ��Name$ TypeHere��5C      $��0��6$   $��1��6.   $��70(�6;    �� TextAlignment$ Right=�6I   $��10��6_   
������ $��0q�6�    � 5E   
   -   5          �Name$ SecondaryFrame��5E        � NavigationUIVisibility$ Hidden=�6(   $��2��6H   $��10��6U   5G      5H      