   M S B A M L   `   `   `  ����F  BTileNavPane, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:TileNavPane.ViewTileNavPane.View  5	      #    TileNavPane.View.VentanaCobro   5      a ]DevExpress.Xpf.Core.v22.1, Version=22.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ] YDevExpress.Mvvm.v22.1, Version=22.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aAdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm   5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      *localclr-namespace:TileNavPane.View  5	      a ]DevExpress.Xpf.Grid.v22.1, Version=22.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v22.1.Core, Version=22.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   6<   <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  6{   $	��600��5   8   $	��600��6D   2  ,DevExpress.Mvvm.UI.Interactivity.Interaction    	Behaviors  5      .  (DevExpress.Xpf.Core.CurrentDialogService  5   
   -   5          Name$ VentanaCobroDlg��5   "   -  'DevExpress.Xpf.Core.DXMessageBoxService  5   
   -   5          Name$ 	AlertaDlg��5   !   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $	��150 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5    
   ��  �� Orientation$ 
Horizontal=�6   .+�5!      �� $��PEDIDO: ��6   
���   �$
��Bold"�6;   $��18(�6M   �� 5"      
���   �$
��Bold"�6F   $��18(�6X   ��6   �� *	ID_PEDIDO+6X   5#      �� 5%   
   $��1��6   $��0��6#   $��2��63   .+�5&      %  DevExpress.Xpf.Grid.GridControl  -   5          Name$ GridOrdendes��5&      $	��100��6Z   $
��5000��6j   $
��5000��6{   )  #DevExpress.Xpf.Grid.DataControlBase   SelectionMode$	 Row=�6�      ItemsSource 64   �� *SourceOrdenes+   SelectedItem 6�   �� *SelectedCorreo+	 �� UpdateSourceTrigger$	 PropertyChanged=�
   Columns
 5'      $  DevExpress.Xpf.Grid.GridColumn  5(      -   5          Name$ NOMBRE_PRODUCTO��5(   %   $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ NOMBRE_PRODUCTO��6>   $  DevExpress.Xpf.Grid.BaseColumn   Header)	  #DevExpress.Xpf.Core.ObjectConverter$ PRODUCTO	 6Z      Width2
  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$	 300
 6l     5)      -   5        $ CANTIDAD��5)   %   $ CANTIDAD��67     5*      -   5        $ CON_TODO��5*   %   $ CON_TODO��67   $ CON TODO	 6L   $	 300
 6^     5+      -   5        $ CON_TODO_MENOS��5+   %   $ CON_TODO_MENOS��6=   $ CON TODO MENOS	 6X     5,      -   5        $ COMENTARIOS��5,   %   $ COMENTARIOS��6:   $ COMENTARIOS	 6R     5-      -	   5        $ TOTAL_ORDEN��5-   %   $ TOTAL_ORDEN��6:   $ TOTAL ORDEN	 6R      View 5/      #  DevExpress.Xpf.Grid.TableView  50      &   DevExpress.Xpf.Grid.DataViewBase   ShowTotalSummary . &   DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .     AllowMasterDetail .     AllowEditing .      RowCellMenuCustomizations 51      '  !DevExpress.Xpf.Bars.BarButtonItem  52      !  DevExpress.Xpf.Bars.BarItem   Content$ Eliminar Orden	 60      Command 6J   ��  �� ElementName$ GridOrdendes�� �� Path$$ DataContext.BorrarOrdenCommand�   CommandParameter 6�   �� $ GridOrdendes��$ SelectedItem�54      56      57      � 5;   
   $��2��6   $��1��6    � ColumnDefinitions 5<      �� 5=      $
��auto �6#   �� 5>      $
��auto �6#   .+�5@      �� $ 
Horizontal=�6   $��0��63   .+�5A      �� $��NOMBRE CLIENTE:��6   $
��Left=�62   $	��Top=�6M   $��23��6e   $��	10,0,10,0q�6q   $��DemiBold"�6�   %  DevExpress.Xpf.Editors.TextEdit  5B      -
   5          Name$ NombreCliente��5B       $��27��68   $
��Left=�6D   $	��Top=�6`   $	��170��6�   %  DevExpress.Xpf.Editors.BaseEdit   	EditValue 6x   �� *NOMBRE_CLIENTE+6�   5D      �� 5E      $ 
Horizontal=�6   $��1��63   .+�5F      �� $��TELEFONO CLIENTE:��6   $
��Left=�64   $	��Top=�6O   $��23��6g   $��	10,0,10,0q�6s   $��DemiBold"�6�     5G      -   5        $ TelefonoCliente��5G       $��27��6:   $
��Left=�6F   $	��Top=�6b      MaskType$ Numeric=�6�      Mask$ n0��6�   $	��160��6�    6z   �� *TELEFONO_CLIENTE+6�   5I      5J      �� 5M   
   $��3��6   $��0��6"   $��2��62   .+�5N      �� $��COMENTARIO PEDIDO:��6   $
��Left=�61   $��23��6L   $	��140��6X   $��DemiBold"�6d     5O      -   5        $ ComentariosPedido��5O      $��60��67    6C   �� *COMENTARIO_PEDIDO+ �� Mode$ TwoWay=�$	 PropertyChanged=�5P      �� 5R   
   $ 
Horizontal=�6   $��4��6.   $��0��6;   .+�5S      &   DevExpress.Xpf.Editors.CheckEdit  -   5           Name$  checkDisable��5S      !   Content$! PARA LLEVAR?	 6U   $
��Left=�6l   $	��Top=�6�   $��DemiBold"�6�   {�.   63   �� *PARA_LLEVAR+6�   5T      �� 5V   
   $ 
Horizontal=�6   $��5��6.   $��0��6;   .+�5W      �� $��Metodo de Pago:��6   $
��Left=�6.   $	��Top=�6I   $��23��6a   $��	10,0,10,0q�6m   $��DemiBold"�6�   )  #DevExpress.Xpf.Editors.ComboBoxEdit  5X      -   5        "  Name$" micombo��5X      $
��Left=�60   $	��Top=�6�   $	��200��6�   +  %DevExpress.Xpf.Editors.LookUpEditBase#   ItemsSource# 6K   �� *
metodoPago+ 6o   �� *MetodoPagoSeleccionado+$ TwoWay=�$	 PropertyChanged=�5Y      5\      �� 5^   
   $ 
Horizontal=�6   $��6��6.   $��2��6<   .+�5_      �� $��Total Neto: ��6   
���   �$
��Bold"�6>   $��18(�6P   �� 5`      -   5        $ ��Name$$ TotalPedido��5`      
���   �$
��Bold"�6j   $��18(�6|   ��6)   �� *TOTAL_PEDIDO+$ TwoWay=�6|   5a      �� 5c   
   $ 
Horizontal=�6   $��7��6.   $��0��6;   .+�5d      �� $��Propina:��6   $
��Left=�6'   $	��Top=�6B   $��23��6Z   $��	10,0,10,0q�6f   $��DemiBold"�6z     5e      -   5        $ Propina��5e      $��27��6.   $
��Left=�6:   $	��Top=�6V   $	��170��6�    6n   �� *	PROPINA+$ TwoWay=�6�   �� 5g      $��
Propina %:��6   $
��Left=�6)   $	��Top=�6D   $��23��6\   $��	10,0,10,0q�6h   $��DemiBold"�6|     5h      -   5        $ PorcentajePropina��5h      $��27��68   $
��Left=�6D   $	��Top=�6`   $	��170��6�    6x   �� *PORCENTAJE_PROPINA+$ OneWay=�6�   5i      �� 5k   
   $ 
Horizontal=�6   $��8��6.   $��0��6;   .+�5l      �� $��Total Bruto:��6   
���   �$
��Bold"�6>   $��18(�6P   �� 5m      
���   �$
��Bold"�6G   $��18(�6Y   ��6   �� *TOTAL_BRUTO+6Y   5n      �� 5p   
   $ 
Horizontal=�6   $��9��6.   $��2��6<   .+�5q      &   DevExpress.Xpf.Core.SimpleButton  $��Cobrar��6   $	��140��6T   $��27��6`   $��DemiBold"�6l   % � Cursor$
% Hand��6�   & J� RenderTransformOrigin$& 
0.521,0.63&�6�   ��6/   �� *CobrarPedidoCmd+6�     5r      $��Cancelar��6   $	��140��6S   $��27��6_   $��DemiBold"�6k   $
% Hand��6�   ��61   �� *CancelarCmd+6�   5s      5u      5v      