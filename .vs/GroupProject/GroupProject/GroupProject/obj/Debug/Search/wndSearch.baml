   M S B A M L   `   `   `  ����G  CGroupProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GroupProject.SearchGroupProject.Search  5   	   #    GroupProject.Search.wndSearch   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:GroupProject.Search     5   	     � Title$  Lemonade Invoice Search��5   	   $	��442��6)   $	��484��66    � Icon$@ :/GroupProject;component/Icons/iconfinder_lemon_2003191.png��6B   $	��250��6�   $	��250��6�   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��135* �6   �� 5      $
��284* �6   ��5   
   �� 5       �� EndPoint$ 0.5,.5&�6"    � MappingMode$ Absolute=�64    �� 
StartPoint$ 0.5,0&�6K   .��5      �  � Color$ White��6   � 5      $ 	#FF1F6989��6    � Offset$ 0.126Q�61   � 5      $ 	#FF29708E��6   $ 0.121Q�61   5      .+�5   
   �� -   5         ��Name$ 	btnSelect��5      $��Select��6$   $
��Left=�65   $��	10,68,0,0q�6P   $	��Top=�5      $��75��6)   $��20(�64   
����������	#FF29708E5   $   �� 5   
   -   5        $ 	btnCancel��5      $��Cancel��6$   $
��Left=�65   $��10,5,0,0q�6P   $	��Top=�5      $��75��6)   $��20(�64   
����������	#FF29708E$��1��5   ;   &   System.Windows.Controls.DataGrid  5   
   -   5        	  Name$	 
dgInvoices��5   /   
   AutoGenerateColumns
 .  $��
95,68,0,71q�6C      
IsReadOnly . $��2��6i   $
��Left=�6z   $	��315��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%      Header$ Invoice Number��6/   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   ��  �� Path$ 
InvoiceNum�6m     5      $ Invoice Date��6%    6;   �� $ InvoiceDate�6b     5      $ 
Total Cost��6%    69   �� $ 	TotalCost�6^   5!      �� 5"   
   -   5         ��Name$ cboNum��5"      $
��Left=�6#   $��	10,25,0,0q�6>   $	��Top=�6Q   $	��120��6i   6u   �� 5#   
   -   5        $ cboDate��5#      $
��Left=�6$   $��
151,25,0,0q�6?   $	��Top=�6S   $	��120��6k   6w   �� 5$   
   -   5        $ cboCost��5$      $
��Left=�6$   $��
290,26,0,0q�6?   $	��Top=�6S   $	��120��6k   6w   �� 5%   
   -   5        $ btnReset��5%      $��Reset��6#   $
��Left=�63   $��
10,104,0,0q�6N   $	��Top=�5&      $��75��6)   $��20(�64   
����������	#FF29708E$��30��5'   ;   �� 5(   
   -   5         ��Name$ lblNum��5(      $��Invoice Number��6    $
��Left=�69   $��
177,-1,0,0q�6T   $	��Top=�6h   ���	#FF29708E6�   �� 5)   
   -	   5        $	 lbl��5)      $��Invoice Date��6   $
��Left=�64   $��	334,0,0,0q�6O   $	��Top=�6b   ���	#FF29708E6z   �� 5*   
   -
   5        $ lblCost��5*      $��
Total Cost��6!   $
��Left=�66   $��	491,0,0,0q�6Q   $	��Top=�6d   ���	#FF29708E6|   5,      5-      