   M S B A M L   `   `   `  ����B  >Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ManagerManager  5   	   5clr-namespace:Manager.viewmodelManager.viewmodel  5   	   =#clr-namespace:Manager.CustomControlManager.CustomControl  5   	   -clr-namespace:Manager.ModelManager.Model  5	   	       Manager.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Manager     5   	   .vmclr-namespace:Manager.viewmodel     5   	   2cc#clr-namespace:Manager.CustomControl     5   	   -modelclr-namespace:Manager.Model     5	   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3b+http://schemas.microsoft.com/xaml/behaviors  63   -   5          �Name$  
mainWindow��5   J    � Title$ FILE MANAGER��6	   $	��450��6   $	��900��6+   
����� � � DataContext 5      ,  &Manager.viewmodel.FileManagerViewModel  5   
   .��5      � $��0,0,0,-6q�6   .+�5   
   �� $
��Left=�6   $	��385��60   $	��Top=�6=   $	��199��6U   
����·�$��0,49,0,0q�6{    J� RenderTransformOrigin$ 0.5,0.5&�6�   z�5      V� 5      .~�5      �� �� 5       �� AngleX$ -0.252Q�6$   �� 5      T� 5       T� X$ 0.796Q�6)   5       � 	Resources 5         ButtonFunction �� UpdateSourceTrigger �� ElementName��%�   &	        �� 5      .R�5      �� 
������ $
��Left=�5      ��5      �� *name+$ PropertyChanged=���5      �� ��5      �� *!DataContext.GetFilesListCommand+$ 
mainWindow����5       �� 5!      5"      5#      .+�5%      �� ��5&      �� 5'      	 �� 
TargetType"	 ��6   
 �� Triggers
 5(      �� 5)       �� Binding 6*   �� *FavouriteFolders.Count+$ PropertyChanged=� �� Value 06z   .a�5*   "   ��  �� Property � y� �� Value$ 	Collapsed=�6?   5+      �� 5,       6*   �� *FavouriteFolders.Count+$ PropertyChanged=� 6z   Z� .a�5-   "   ��  � y�$ 	Collapsed=�6?   5.      50      .+�52      �� $��22��6   $��	Favourite��6(   $
��Wrap=�69   $	��117��6M   �� 53      ��54      �� *FavouriteFolders+$ PropertyChanged=�56      �� 57      $��21��6   $��RemoteFolders��6$   $
��Wrap=�69   $	��116��6M   $��14(�6Y    �� TextAlignment$
 Left=�6g   $��Center=�6|   $
��Bold"�6�    6�   �� *GetFilesListCommand+�� 58      #��[  59      $��53��5:   \   ��6   �� *RemoteFolders+$ PropertyChanged=�6\   �� 5<      $��21��6   $��Library��6$   $
��Wrap=�63   $	��116��6G   $��14(�6S   $
��Bold"�6a   �� 5=      #��[  5>      ��5?      �� *LibraryFolders+$ PropertyChanged=��� 5A      $��21��6   $��Devices��6$   $
��Wrap=�63   $	��116��6G   $��14(�6S   $
��Bold"�6a   �� 5B      #��[  5C      ��5D      �� *ConnectedDevices+$ PropertyChanged=�5E      �� 5F   
   -   5         ��Name$ 
AddressBar��5F      $
��Left=�6&   $��22��6A   $��
224,50,0,0q�6M    �� TextWrapping$
 Wrap=�5H      $	��Top=�5I      $	��676��5J      ��5G      �� *CurrentDirectory+$ PropertyChanged=�.��5J       J� InputBindings 5K      �� 5L      
 �� Key$ Enter��5M       �� Command 5N      �� *NavigateToPath+ �� CommandParameter 5O      �� *Text+$ 
AddressBar��.��5P   %   5Q      �� 5S   
   -   5         ��Name$ ListViewControl��5T      $��6��5S      $
��Left=�5U      
������ $	��358��5W      $��
200,72,0,0q�6    $	��Top=�5X      $	��700��6+   $��Disabled=�5Y      $
��Auto=�5Z      
���   � �� SelectionMode$ Extended=�5]       �� SelectedItem 5[      ��  �� Mode$ OneWay=���5^      �� *NavigationFolderFiles+$ PropertyChanged=�*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5_      +  %Microsoft.Xaml.Behaviors.EventTrigger  5`         	EventName$ MouseDoubleClick��6!   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5a      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 5b      �� *GetFilesListCommand+   CommandParameter 5c      �� *SelectedItem+$ ListViewControl��5d        5e      $ SelectionChanged��6!   . 5f         5g      �� *GetFilesListCommand+ 5h      �� *SelectedItem+$ ListViewControl��5i       �� View 5k      �� 5l      .P�5m      �� 5n      5q      �� 5r   
   -   5          ��Name$  adressButton��5r      $�� ��6'   $
��Left=�62   $��22��6M   $��
200,50,0,0q�6Y   $	��Top=�6m   $��24��6�   ��5s      �� 5t      ! �� ImageSource$! /computer-icon.png��6   5v      �� 5w   
   $��Center=�6   $��50��6-   $	��Top=�69   $	��900��6Q   $��/ocean-3605547__480.jpg��6]   $��UniformToFill=�6~   5y      5z      