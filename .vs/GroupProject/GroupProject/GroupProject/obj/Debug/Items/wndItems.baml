   M S B A M L   `   `   `  ����G  CGroupProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:GroupProject.ItemsGroupProject.Items  5   	   !    GroupProject.Items.wndItems   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:GroupProject.Items     5   	     � Title$  
Edit Items��5   	   $	��432��6   $	��510��6)   $	��510��65   $	��510��6D    � Icon$" iconfinder_lemon_2003191.png��6S   $��80��6w   $
��1000��6�   .��5	      � $��0,0,2,0q�6   ��5
   
   �� 5       �� EndPoint$ 250,400&�6"    � MappingMode$ Absolute=�65    �� 
StartPoint$ 250,0&�6L   .��5      �  � Color$ White��6   � 5      $ 	#FF1F6989��6    � Offset$ 0.126Q�61   � 5      $ 	#FF29708E��6   $ 0.058Q�61   5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
dgItemList��5   /      AutoGenerateColumns .  $��10,217,0,10q�6C   	   CanUserAddRows	 .  $	��463��6�   $
��Left=�6�   $	��463��6�   
   
IsReadOnly
 .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Item Code��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   ��  �� Path$ ItemCode�6\     5         Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%   $ Item Description��6/    6I   �� $ ItemDesc�6m     5      $ 	Item Cost��6%    68   �� $ ItemCost�6\   5      �� 5   
   -   5         ��Name$ gbItemManagement��5      $��Item Management��6-   $	��202��6F   $��	10,10,0,0q�6S   $	��Top=�5      $
��Left=�6+   $	��463��6F   .��5      � $	��173��6   $��0,0,-2,0q�6    $	��Top=�62   .+�5      �� -   5         ��Name$ btnAddItems��5      $��Add Item��6.   $
��Left=�6A   $��	10,15,0,0q�6\   $	��Top=�5      $��75��61   $��35��6V   $��0��6b   
����������	#FF29708E5   ,   �� 5      -   5         ��Name$ txtItemCode��5      $
��Left=�6/   $��23��6J   $��
204,15,0,0q�6V    �� TextWrapping$
 Wrap=�6j   $�� ��6~   $	��Top=�6�   $��40��6�   $��4��6�    J� RenderTransformOrigin$ 0.458,-0.913&�6�    �� 	MaxLength$ 4��6�   �� 5      -   5        $ txtItemDesc��5      $
��Left=�6/   $��70��6J   $��
204,53,0,0q�6V   $
 Wrap=�6j   $�� ��6~   $	��Top=�6�   $	��120��6�   $��5��6�   $ 39��6�   �� 5       -   5        $ txtItemCost��5       $
��Left=�6/   $��23��6J   $��204,135,0,0q�6V   $
 Wrap=�6k   $�� ��6   $	��Top=�6�   $	��122��6�   $��6��6�   $ 8��6  6"  �� 5!      -   5        $ btnEditItem��5!      $��	Edit Item��6.   $
��Left=�6B   $��
368,15,0,0q�6]   $	��Top=�5"      $��75��61   $��35��6V   $��1��6b   {�.  
����������	#FF29708E5#   >   �� 5$      -   5        $ btnDeleteItem��5$      $��Delete Item��60   $
��Left=�6F   $��	10,53,0,0q�6a   $	��Top=�5%      $��75��61   $��35��6X   $��2��6d   {�.  
����������	#FF29708E5&   >   �� 5'      -	   5        $ btnExit��5'      $
��Exit��6*   $
��Left=�69   $��	10,93,0,0q�6T   $	��Top=�5(      $��75��61   $��35��6<   $��3��6^   
����������	#FF29708E5)   ,   �� 5*      -
   5         ��Name$ lblItemCode��5*      $��	Item Code��6-   $
��Left=�6A   $��
134,15,0,0q�6\   $	��Top=�5+      $ 1.368,0.423&�60   
�������6T   �� 5,      -   5        $ lblItemDesc��5,      $��Item Description��6-   $
��Left=�6H   $��
107,53,0,0q�6c   $	��Top=�5-      
�������60   �� 5.      -   5        $ lblItemCost��5.      $��	Item Cost��6-   $
��Left=�6A   $��138,135,0,0q�6\   $	��Top=�5/      
�������60   �� 50      -   5        $ btnSaveEdit��50      $��Save Changes��6.   $
��Left=�6E   $��
368,56,0,0q�6`   $	��Top=�51      $��75��61   $��35��6V   $��1��6b   {�.  $��11(�52   +   ���	#FF29708E
�������6P   �� 53      -   5        $ btnCancelEdit��53      $��Cancel��60   $
��Left=�6A   $��
368,96,0,0q�6\   $	��Top=�54      $��75��61   $��35��6X   $��1��6d   {�.  $��11(�55   +   
����������	#FF29708E6L   56      57      58      59      