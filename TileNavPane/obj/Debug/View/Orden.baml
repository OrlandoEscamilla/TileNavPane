   M S B A M L   `   `   `  ����F  BTileNavPane, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:TileNavPane.ViewTileNavPane.View  5          TileNavPane.View.Orden   5      a ]DevExpress.Xpf.Core.v22.1, Version=22.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ] YDevExpress.Mvvm.v22.1, Version=22.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aAdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm   5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5	      *localclr-namespace:TileNavPane.View  5      a ]DevExpress.Xpf.Grid.v22.1, Version=22.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v22.1.Core, Version=22.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   6;   <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  6z   $	��600��5   7   $	��600��6C   2  ,DevExpress.Mvvm.UI.Interactivity.Interaction    	Behaviors  5      .  (DevExpress.Xpf.Core.CurrentDialogService  5   
   -   5          Name$ OrdenCurrentDlg��5   "   -  'DevExpress.Xpf.Core.DXMessageBoxService  5   
   -   5          Name$ 	AlertaDlg��5   !   .��5      �  � Cursor$  ��6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $	��100 �6   �� 5      $
��auto �6   �� 5      $
��Auto �6   �� 5      $��50 �6   �� 5      $	��100 �6   �� 5      $��50 �6   �� 5      $��50 �6    � ColumnDefinitions 5"   
   �� 5#      $	��300 �6   �� 5$      $	��300 �6   .+�5(   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��0��6;   .+�5)      �� $��	PRODUCTO:��6   $
��Left=�6(   $	��Top=�6C   $��23��6[   $��	10,0,10,0q�6g   $��DemiBold"�6{   )  #DevExpress.Xpf.Editors.ComboBoxEdit  5*      -   5          Name$ Producto��5*      $
��Left=�61   $	��Top=�6�   $	��200��6�   +  %DevExpress.Xpf.Editors.LookUpEditBase   DisplayMember$ NOMBRE_PRODUCTO��6�   	   ValueMember$	 NOMBRE_PRODUCTO��6  
   ItemsSource
 6L   �� *DatasourceProductos+%  DevExpress.Xpf.Editors.BaseEdit   	EditValue 6x   �� *NOMBRE_PRODUCTO+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5+      5,      �� 5.   
   $ 
Horizontal=�6   $��0��6.   $��1��6;   .+�5/      �� $��	CANTIDAD:��6   $
��Left=�6(   $	��Top=�6D   $��23��6\   $��DemiBold"�6i   $��	10,0,10,0q�6   %  DevExpress.Xpf.Editors.TextEdit  50      -   5          Name$ text_CANTIDAD��50      $��27��64   $
��Left=�6@   $	��Top=�6\      MaskType$ Numeric=�6�      Mask$ n0��6�   $	��100��6�    6t   �� *
CANTIDAD+6�   51      �� 53   
   $ 
Horizontal=�6   $��1��60   $��0��6=   $��2��6N   .+�54      	� -   5         	�Name$ contodo��54   -   $��Con todo��6   $��	10,0,17,0q�6�   ��6>   �� *commandRadio+��6_   �� *	Content+ �� ElementName$ contodo�� d� 	IsChecked 6�   �� *	CONTODO+6�   	� 55      -   5        $ contodomenos��55   3   $��Con todo menos��6   ��6I   �� *commandRadio+��6j   �� *	Content+$ contodomenos�� 6�   �� *CONTODOMENOS+  56      $	��350��6H   $��1��6T   $��25��6i   $��10,0,0,0q�6u   
 6   �� *listIngredientes+{�6�   �� *	habilitar+ 6�   �� *INGREDIENTES+$ TwoWay=�   StyleSettings 57      7  1DevExpress.Xpf.Editors.TokenComboBoxStyleSettings  58      5:      5<      �� 5@   
   $��2��6   $��0��6%   $��2��65   .+�5A      �� $��COMENTARIOS:��6   $
��Left=�6+   $��23��6F   $	��140��6R   $��DemiBold"�6^     5B      -   5        $ Comentarios��5B      $��60��61    6=   �� *COMENTARIOS+$ TwoWay=�$ PropertyChanged=�5C      �� 5E   
   $��3��6   $��1��6#   .+�5F      &	   DevExpress.Xpf.Core.SimpleButton	  $��Agregar orden��6   $��Right=�6Z   $��Center=�6v   $	��140��6�   $��27��6�   $��DemiBold"�6�   $
 Hand��6�   ��66   �� *AddOrdenCommand+6�   5G      �� 5I   
   $��4��6   $��0��6#   $��2��63   .+�5J      %
  DevExpress.Xpf.Grid.GridControl
  -   5         
 Name$ GridOrdendes��5J      $	��100��6Z   $
��5000��6j   $
��5000��6{   )  #DevExpress.Xpf.Grid.DataControlBase   SelectionMode$	 Row=�6�      ItemsSource 64   �� *SourceOrdenes+   SelectedItem 6�   �� *SelectedCorreo+$ PropertyChanged=� 
  Columns 5K      $  DevExpress.Xpf.Grid.GridColumn  5L      -	   5          Name$ NOMBRE_PRODUCTO��5L   )   $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ NOMBRE_PRODUCTO��6B   $  DevExpress.Xpf.Grid.BaseColumn   Header)  #DevExpress.Xpf.Core.ObjectConverter$ PRODUCTO 6^      Width2  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$	 300 6p     5M      -
   5        $ CANTIDAD��5M   )   $ CANTIDAD��6;     5N      -   5        $ CON_TODO��5N   )   $ CON_TODO��6;   $ CON TODO 6P   $	 300 6b     5O      -   5        $ CON_TODO_MENOS��5O   )   $ CON_TODO_MENOS��6A   $ CON TODO MENOS 6\     5P      -   5        $ COMENTARIOS��5P   )   $ COMENTARIOS��6>   $ COMENTARIOS 6V     5Q      -   5        $ TOTAL_ORDEN��5Q   )   $ TOTAL_ORDEN��6>   $ TOTAL ORDEN 6V    
  View 5S      #  DevExpress.Xpf.Grid.TableView  5T      &   DevExpress.Xpf.Grid.DataViewBase   ShowTotalSummary . &   DevExpress.Xpf.Grid.GridViewBase    ShowGroupPanel  .  !   AllowMasterDetail! .  "   AllowEditing" .   #   RowCellMenuCustomizations# 5U      '  !DevExpress.Xpf.Bars.BarButtonItem  5V      !  DevExpress.Xpf.Bars.BarItem$   Content$$ Eliminar Orden 60   %   Command% 6J   �� $ GridOrdendes��& �� Path$$& DataContext.BorrarOrdenCommand�'   CommandParameter' 6�   �� $ GridOrdendes��$& SelectedItem�5X      5Z      5[      �� 5]   
   $ 
Horizontal=�6   $��5��6.   $��0��6;   .+�5^      �� $��NOMBRE CLIENTE:��6   $
��Left=�6.   $	��Top=�6I   $��23��6a   $��	10,0,10,0q�6m   $��DemiBold"�6�     5_      -   5        $ NombreCliente��5_      $��27��64   $
��Left=�6@   $	��Top=�6\   $	��170��6�    6t   �� *NOMBRE_CLIENTE+6�   5a      �� 5c   
   $ 
Horizontal=�6   $��5��6.   $��1��6;   .+�5d      �� $��TELEFONO CLIENTE:��6   $
��Left=�60   $	��Top=�6K   $��23��6c   $��	10,0,10,0q�6o   $��DemiBold"�6�     5e      -   5        $ TelefonoCliente��5e      $��27��66   $
��Left=�6B   $	��Top=�6^   $ Numeric=�6�   $ n0��6�   $	��160��6�    6v   �� *TELEFONO_CLIENTE+6�   5f      �� 5h   
   $��6��6   $��0��6"   $��2��62   .+�5i      �� $��COMENTARIO PEDIDO:��6   $
��Left=�61   $��23��6L   $	��140��6X   $��DemiBold"�6d     5j      -   5        $ ComentariosPedido��5j      $��60��67    6C   �� *COMENTARIO_PEDIDO+$ TwoWay=�$ PropertyChanged=�5k      �� 5m   
   $ 
Horizontal=�6   $��7��6.   $��0��6;   .+�5n      &   DevExpress.Xpf.Editors.CheckEdit  -   5        (  Name$( checkDisable��5n      )   Content$) PARA LLEVAR? 6U   $
��Left=�6l   $	��Top=�6�   $��DemiBold"�6�    63   �� *PARA_LLEVAR+6�   5o      �� 5r   
   $ 
Horizontal=�6   $��7��6.   $��1��6;   $��2��6K   .+�5s      �� $
��Left=�65   $��23��6P   $	��140��6\   $��DemiBold"�6h   ��6   �� *TOTAL_PEDIDO+6h   5t      �� 5v   
   $ 
Horizontal=�6   $��8��6.   $��1��6;   $��2��6K   $  ��6_   .+�5w      	  $��Guardar��6   $	��140��6S   $��27��6_   $��DemiBold"�6k   $
 Hand��6�   * J� RenderTransformOrigin$* 
0.521,0.63&�6�   ��60   �� *ActualizarCmd+6�   	  5x      $��Cancelar��6   $	��140��6S   $��27��6_   $��DemiBold"�6k   $
 Hand��6�   ��61   �� *CancelarCmd+6�   5y      5{      5|      