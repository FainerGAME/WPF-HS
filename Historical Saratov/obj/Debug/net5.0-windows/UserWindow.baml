   M S B A M L   `   `   `  ����M  IHistorical Saratov, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Historical_SaratovHistorical_Saratov  5   	   #    Historical_Saratov.UserWindow   5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   2local clr-namespace:Historical_Saratov     5   	     � Title$  
UserWindow��5	   	   $	��450��6   $	��800��6)      MaterialDesignBody#���   5
   	    � AllowsTransparency$
 True��5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   ��5   	   Z� .��5      �   MaterialDesignPaper#��[ 5   	    � ColumnDefinitions 5   
   �� 5      $	��100 �6   6-   �� 5      $
��700* �6   6.   .+�5   
   �� $��0��5      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�5      $
��Left=�5      $��Center=�5      $��30 0 0 0q�5      .+�5      �� $	��Top=�5      .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ 
PrimaryMid=�5        * &MaterialDesignNavigationRailTabControl#��[ 5!      .@�5"      �� ��5#      �� 5$      -   5        $
��auto��5%      $
��auto��5&      .+�5)      '  !MaterialDesignThemes.Wpf.PackIcon  $��24��5*   !   $��24��5+   !   $��Center=�5,   !      Kind$
 Home=�5-   !   �� 5.      $��Center=�5/   !   $
��Home��50   !   52      54      �� 57      ��58      �� 59      -   5        $
��auto��5:      $
��auto��5;      .+�5>        $��24��5?   !   $��24��5@   !   $��Center=�5A   !   $ FormatListText=�5B   !   �� 5C      $��Center=�5D   !   $
��List��5E   !   5G      5I      �� 5J      ��5K      �� 5L      -   5        $
��auto��5M      $
��auto��5N      .+�5Q        $��24��5R   !   $��24��5S   !   $��Center=�5T   !   $	 Map=�5U   !   �� 5V      $��Center=�5W   !   $	��Map��5X   !   5Z      5\      �� 5]      ��5^      �� 5_      -   5        $
��auto��5`      $
��auto��5a      .+�5c        $��24��5d   !   $��24��5e   !   $��Center=�5f   !   $ Account=�5g   !   �� 5h      $��Center=�5i   !   $��Profile��5j   !   5l      5n      �� 5o      ��5p      �� 5q      -   5        $
��auto��5r      $
��auto��5s      .+�5v        $��24��5w   !   $��24��5x   !   $��Center=�5y   !   $	 Cog=�5z   !   �� 5{      $��Center=�5|   !   $��Settings��5}   !   5      5�      �� 5�      ��5�      �� 5�      -   5        $
��auto��5�      $
��auto��5�      .+�5�        $��24��5�   !   $��24��5�   !   $��Center=�5�   !   $ 	ExitToApp=�5�   !   �� 5�      $��Center=�5�   !   $
��Exit��5�   !   5�      5�      5�      5�       � 5�   
   -   5          �Name$ MyFrame��5�      $��1��5�      	  � Source$	 Pages/MainPageUser.xaml?�5�      
  � NavigationUIVisibility$
 Hidden=�5�      5�      5�      5�      