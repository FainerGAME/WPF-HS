   M S B A M L   `   `   `  ����M  IHistorical Saratov, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Historical_SaratovHistorical_Saratov  5   	   $    Historical_Saratov.AdminWindow   5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   2local clr-namespace:Historical_Saratov     5   	      MaterialDesignBody#���   5	   	     � AllowsTransparency$
  True��5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ AdminWindow��5   	   $	��450��6   $	��800��6*   ��5
   	   Z� .��5      �   MaterialDesignPaper#��[ 6    � ColumnDefinitions 5   
   �� 5      $	��100 �6   6-   �� 5      $
��700* �6   6.   .+�5   
   �� $��0��5      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�5      $
��Left=�5      $��Center=�5      $��30 0 0 0q�5      .+�5      �� $	��Top=�5      .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ 
PrimaryMid=�5       * &MaterialDesignNavigationRailTabControl#��[ 5      .@�5      �� ��5       �� 5!      -   5        $
��auto��5"      $
��auto��5#      .+�5&      '  !MaterialDesignThemes.Wpf.PackIcon  $��24��5'   !   $��24��5(   !   $��Center=�5)   !      Kind$
 Home=�5*   !   �� 5+      $��Center=�5,   !   $
��Home��5-   !   5/      51      �� 54      ��55      �� 56      -   5        $
��auto��57      $
��auto��58      .+�5;        $��24��5<   !   $��24��5=   !   $��Center=�5>   !   $ Domain=�5?   !   �� 5@      $��Center=�5A   !   $��Build��5B   !   5D      5F      �� 5G      ��5H      �� 5I      -   5        $
��auto��5J      $
��auto��5K      .+�5N        $��24��5O   !   $��24��5P   !   $��Center=�5Q   !   $ Pillar=�5R   !   �� 5S      $��Center=�5T   !   $��Architector��5U   !   $��14(�5V   !   5X      5Z      �� 5[      ��5\      �� 5]      -   5        $
��auto��5^      $
��auto��5_      .+�5a        $��24��5b   !   $��24��5c   !   $��Center=�5d   !   $ Account=�5e   !   �� 5f      $��Center=�5g   !   $��Profile��5h   !   5j      5l      �� 5m      ��5n      �� 5o      -   5        $
��auto��5p      $
��auto��5q      .+�5t        $��24��5u   !   $��24��5v   !   $��Center=�5w   !   $	 Cog=�5x   !   �� 5y      $��Center=�5z   !   $��Settings��5{   !   5}      5      �� 5�      ��5�      �� 5�      -   5        $
��auto��5�      $
��auto��5�      .+�5�        $��24��5�   !   $��24��5�   !   $��Center=�5�   !   $ 	ExitToApp=�5�   !   �� 5�      $��Center=�5�   !   $
��Exit��5�   !   5�      5�      5�      5�       � 5�   
   -   5          �Name$ MyFrame��5�      $��1��5�      	  � Source$	 Pages/MainPageAdmin.xaml?�5�      
  � NavigationUIVisibility$
 Hidden=�5�      5�      5�      5�      