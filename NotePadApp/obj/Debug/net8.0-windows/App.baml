   M S B A M L   `   `   `  ����H  DNotePadApp, Version=2024.1.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:NotePadApp
NotePadApp  5      b ^PresentationFramework.Aero2, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes 5          NotePadApp.App   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      *localclr-namespace:NotePadApp     5      ]themeKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2     5        �� 	Resources  5       �� MergedDictionaries �� Source   	AppSymbol �� 
TargetType �� Property �� Value  HeaderFooterText  Button.MouseOver.Background �� Color  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border  Button.Disabled.Foreground 	 ButtonTemplate �� 
TargetType ��Name	 �� CornerRadius
 J� SnapsToDevicePixels ��Name �� Triggers P� Property P� Value �� 
TargetName 
 ButtonMouseOver  ButtonPressed  FocusVisual �� StrokeDashArray  TabItem.Static.Background  TabItem.Static.Border   TabItem.MouseOver.Background  TabItem.MouseOver.Border  TabItem.Selected.Background  TabItem.Selected.Border  TabItem.Disabled.Background  TabItem.Disabled.Border �Name ��Name  	Seperator F�Name  HeaderFooter �� Stretch J� Opacity �� RelativeSource �� AncestorType �� Orientation ��Name A�Name  IsSavedColor �� ScaleX  Tab ^� 
Conditions �� Binding �� Mode �� Value  NotSelectedTab  ]� 
Conditions! �� Property" �� Value# �� Binding�� 5
   
    5      �� 5      $ /Themes/DarkTheme.xaml?�6%   �� 5      $! /Styles/WindowNavStyle.xaml?�6%   �� 5      $ /Styles/MenuStyle.xaml?�6%   �� 5      $ /Styles/GoToButton.xaml?�6%   �� 5      $  /Styles/ComboBoxStyle.xaml?�6%   �� 5      $$ /Styles/ComboBoxItemStyle.xaml?�6%   %W?  &	        &	 ~    &	 �    &	 �    &	 �    &	     &	 *    &	 M    &		 p    &	 T    &	     &	 @    &	 e    &	 �    &	 �    &	 �    &	 �    &	     '�� ;    7   7 	 �� 5      " ��6&   .�5      ��  � ��
 ���� 6/   �� 5       � ��$ 0q�64   �� 5       � ��$ 30��6*   �� 5       � ��$ 25��6+   �� 5        � ��$
 10pt(�6-   �� 5!       � ��$ Segoe UI Symbol)�6/   �� 5#       � ��# �  6/   �� 5$       � ��$ Center=�6?   �� 5%       � ��$ Center=�6=   5'      �� 5+      $ 	#BE312F38��6B   �� 5,      $
 Gray��6>   �� 5-      $ 	#E6312F38��6@   �� 5.      $ Transparent��6<   �� 5/      $ 	#FFF4F4F4��6A   �� 50      $ 	#FFADB2B5��6=   �� 51      $ 	#FF838383��6A   �� 55      " ��65   .R�56      �� $ border��57      #��z��58      #��z��59      #��z��5:      $	 5��5;      $

 true��5<      ._�5>      �� $ contentPresenter��5?      #��z��5@      $��Center=�5A      $��Center=�5B      $|�False��5C      $
��True��5D      #
 z
 5E      5F       5G      P� 5H       �@��IsDefaulted$
 true��6<   . �5I      �� $ border��6!   # � ��6L    � ��5J      P� 5K       �@J�IsMouseOver$
 true��65   . �5L      �� $ border��6!   # � 
 6K    � ���� 5M      $ border��6!   # �  6L    � ��5N      P� 5O       � ��$
 true��63   . �5P      �� $ border��6!   # �  6K    � ���� 5Q      $ border��6!   # �  6L    � ��5R      P� 5S       � {�$ false��63   . �5T      �� $ border��6!   # �  6K    � ���� 5U      $ border��6!   # �  6L    � ���� 5V      $ contentPresenter��6!   # �  6a    � ��5W      5Y      �� 5Z      .�5[      ��  � �� 5\      �� 5]      .R�5^      �� $��2q�5_   !   $

 true��5`   !   #��� ��5a   !   $	 1 2R�5b   !   $��1��5c   !   5d      5f      5g      �� 5k      $ Transparent��6@   �� 5l      $ Transparent��6<   �� 5m      $ Transparent��6C   �� 5n      $ Transparent��6?   �� 5o      $ Transparent��6B   �� 5p      $ Transparent��6>   �� 5q      $ #F0F0F0��6B   �� 5r      $ #D9D9D9��6>   �� 5w      " ��6   .�5x      ��  �@�FocusVisualStyle# �  65   �� 5y       � ��# �  6/   �� 5z       � ��# �  6/   �� 5{       � ��# �  60   �� 5|       � ��$ 0q�6+   �� 5}       � ��$ 6,2,6,2q�6,   �� 5~       � ��$ Stretch=�6?   �� 5       � ��$ Stretch=�6=   �� 5�       � �� 5�      �� 5�      " ��6*   .R�5�      � $ templateRoot��6#   $

 true��69   .+�5�   "   �� $ SeperatorTwo��5�   %   $��1��5�   %   $��15��5�   %   $��0,0,10,0q�5�   %   $
��Left=�5�   %   $��Center=�5�   %   #���  5�   %   $y�Hidden=�5�   %   F� 5�   "   $ 	LeftShape��5�   %   $��25��5�   %   $��30��5�   %   $
��Left=�5�   %   ]���� -1 Zb�     Zb�     Zb� 	=  Zb���  Q%��� ���р�� ��� Ӏ��      $�  -1	#���  5�   %   $ Uniform=�5�   %   #���  5�   %   $��1��5�   %   �� 5�   "   $ 
mainBorder��5�   %   $��8,0,0,0q�5�   %   #��z��5�   %   #��z��5�   %   $��0q�5�   %   $	 	10 10 0 0��5�   %   ._�5�   &   �� $ innerBorder��5�   )   $��-2q�5�   )   #���  5�   )   #���  5�   )   $��0q�5�   )   $	 	10 10 0 0��5�   )   $ 0Q�5�   )   5�   #   �� 5�   "   $ contentPresenter��5�   %   #��z��5�   %   $��Header��5�   %   $|�False��5�   %   $
��True��5�   %   #
 z
 5�   %   ��5�   %   �� *HorizontalContentAlignment+ �� " ����5�   %   �� *VerticalContentAlignment+ �� " ��5�   %   �� 5�   "   $��Right=�5�   %   $��Center=�5�   %   $ 
Horizontal=�5�   %   .+�5�   &   � .+�5�   *   �� $ CloseButton��5�   -   $��0,0,8,0q�5�   -   $	��✖��5�   -   8��  8�� $y�Visible=�5�   -   ��5�   -   �� *Close+5�   -   A� 5�   *   $ IsSaved��5�   -   $��6��5�   -   $��6��5�   -   $��0,0,19,0q�5�   -   $��Right=�5�   -   #���  5�   -   $y�Visible=�5�   -   5�   '   5�   #   �� 5�   "   $ 	Seperator��5�   %   $��1��5�   %   $��15��5�   %   $��0,0,-8,0q�5�   %   $��Right=�5�   %   $��Center=�5�   %   #���  5�   %   $y�Hidden=�5�   %   F� 5�   "   $ 
RightShape��5�   %   $��20��5�   %   $��30��5�   %   $��	0,0,-23,0q�5�   %   $��Right=�5�   %   ]���� -1 Zb�     Zb�     Zb� 	=  Zb���  Q%��� ���р�� ��� Ӏ��      $�  -1	#���  5�   %   $ Uniform=�5�   %   #���  5�   %   $��1��5�   %   z�5�   &   �� 5�   *   $ -1Q�69   5�   #   �� 5�   "   $ InactiveLine��5�   %   $	��250��5�   %   $��1��5�   %   $��
0,26,-40,0q�5�   %   $��Center=�5�   %   #���  5�   %   $y�Hidden=�5�   %   5�       5�      ^� 5�   "    5�   &   �� 5�   *    64   �� *IsMouseOver+ �� $
 Self=� true6   �� 5�   *    64   �� *TabStripPlacement+ �� " �� Left6�   .0�5�   &   �� $ 
mainBorder��6-   # �  6[    � ���� 5�   &   $ 
mainBorder��6-   # �  6\    � ���� 5�   &   $ innerBorder��6-    � ��$ 1,1,0,1q�6a   �� 5�   &   $ 
mainBorder��6-    � ��$ 1,1,0,1q�6`   �� 5�   &   $ 	Seperator��6-    � y�$ 	Collapsed=�6Z   �� 5�   &   $ SeperatorTwo��6-    � y�$ 	Collapsed=�6]   �� 5�   &   $ IsSaved��6-    � y�$ 	Collapsed=�6X   �� 5   &   $ CloseButton��6-    � y�$ Visible=�6\   5  #   ^� 5  "    5  &   �� 5  *    64   �� *IsMouseOver+ �� $
 Self=� true6   �� 5  *    64   �� *TabStripPlacement+ �� " ��
 Bottom6�   .0�5  &   �� $ 
mainBorder��6-   # �  6[    � ���� 5	  &   $ 
mainBorder��6-   # �  6\    � ���� 5
  &   $ innerBorder��6-    � ��$ 1,0,1,1q�6a   �� 5  &   $ 
mainBorder��6-    � ��$ 1,0,1,1q�6`   �� 5  &   $ 	Seperator��6-    � y�$ 	Collapsed=�6Z   �� 5  &   $ SeperatorTwo��6-    � y�$ 	Collapsed=�6]   �� 5  &   $ IsSaved��6-    � y�$ 	Collapsed=�6X   �� 5  &   $ CloseButton��6-    � y�$ Visible=�6\   5  #   ^� 5  "    5  &   �� 5  *    64   �� *IsMouseOver+ �� $
 Self=� true6   �� 5  *    64   �� *TabStripPlacement+ �� " ��	 Right6�   .0�5  &   �� $ 
mainBorder��6-   # �  6[    � ���� 5  &   $ 
mainBorder��6-   # �  6\    � ���� 5  &   $ innerBorder��6-    � ��$ 0,1,1,1q�6a   �� 5  &   $ 
mainBorder��6-    � ��$ 0,1,1,1q�6`   �� 5  &   $ 	Seperator��6-    � y�$ 	Collapsed=�6Z   �� 5  &   $ SeperatorTwo��6-    � y�$ 	Collapsed=�6]   �� 5   &   $ CloseButton��6-    � y�$ Visible=�6\   5#  #   ^� 5$  "    5%  &   �� 5&  *    64   �� *IsMouseOver+ �� $
 Self=� true6   �� 5'  *    64   �� *TabStripPlacement+ �� " �� Top6�   .0�5)  &   �� $ 
mainBorder��6-   # �  6[    � ���� 5*  &   $ 
mainBorder��6-   # �  6\    � ���� 5+  &   $ innerBorder��6-    � ��$ 1,1,1,0q�6a   �� 5,  &   $ 
mainBorder��6-    � ��$ 1,1,1,0q�6`   �� 5.  &   $ 	Seperator��6-    � y�$ 	Collapsed=�6Z   �� 5/  &   $ SeperatorTwo��6-    � y�$ 	Collapsed=�6]   �� 50  &   $ CloseButton��6-    � y�$ Visible=�6\   �� 51  &   $ IsSaved��6-    � y�$ 	Collapsed=�6X   55  #   ^� 56  "    57  &   �� 58  *    64   �� *	IsEnabled+ �� $
 Self=�	 false6}   �� 59  *    64   �� *TabStripPlacement+ �� " �� Left6�   .0�5;  &   �� $ contentPresenter��6-    �@J�Opacity$
 0.56Q�6^   �� 5<  &   $ 
mainBorder��6-   # �  6[    � ���� 5=  &   $ 
mainBorder��6-   # �  6\    � ���� 5>  &   $ innerBorder��6-    � ��$ 1,1,0,1q�6a   �� 5?  &   $ 
mainBorder��6-    � ��$ 1,1,0,1q�6`   5@  #   ^� 5A  "    5B  &   �� 5C  *    64   �� *	IsEnabled+ �� $
 Self=�	 false6}   �� 5D  *    64   �� *TabStripPlacement+ �� " ��
 Bottom6�   .0�5F  &   �� $ contentPresenter��6-    �@J�Opacity$
 0.56Q�6^   �� 5G  &   $ 
mainBorder��6-   # �  6[    � ���� 5H  &   $ 
mainBorder��6-   # �  6\    � ���� 5I  &   $ innerBorder��6-    � ��$ 1,0,1,1q�6a   �� 5J  &   $ 
mainBorder��6-    � ��$ 1,0,1,1q�6`   5K  #   ^� 5L  "    5M  &   �� 5N  *    64   �� *	IsEnabled+ �� $
 Self=�	 false6}   �� 5O  *    64   �� *TabStripPlacement+ �� " ��	 Right6�   .0�5Q  &   �� $ contentPresenter��6-    �@J�Opacity$
 0.56Q�6^   �� 5R  &   $ 
mainBorder��6-   # �  6[    � ���� 5S  &   $ 
mainBorder��6-   # �  6\    � ���� 5T  &   $ innerBorder��6-    � ��$ 0,1,1,1q�6a   �� 5U  &   $ 
mainBorder��6-    � ��$ 0,1,1,1q�6`   5V  #   ^� 5W  "    5X  &   �� 5Y  *    64   �� *	IsEnabled+ �� $
 Self=�	 false6}   �� 5Z  *    64   �� *TabStripPlacement+ �� " �� Top6�   .0�5\  &   �� $ contentPresenter��6-    �@J�Opacity$
 0.56Q�6^   �� 5]  &   $ 
mainBorder��6-   # �  6[    � ���� 5^  &   $ 
mainBorder��6-   # �  6\    � ���� 5_  &   $ innerBorder��6-    � ��$ 1,1,1,0q�6a   �� 5`  &   $ 
mainBorder��6-    � ��$ 1,1,1,0q�6`   5a  #   ^� 5b  "    5c  &   �� 5d  *    64   �� *
IsSelected+ �� $
 Self=�	 false6~   �� 5e  *    64   �� *TabStripPlacement+ �� " �� Left6�   .0�5g  &   �� $ innerBorder��6-    � ��$ 1,1,0,1q�6a   �� 5h  &   $ 
mainBorder��6-    � ��$ 1,1,0,1q�6`   �� 5i  &   $ 	Seperator��6-    � y�$ Visible=�6Z   �� 5j  &   $ SeperatorTwo��6-    � y�$ Visible=�6]   �� 5l  &   $ CloseButton��6-    � y�$ 	Collapsed=�6\   5n  #   ^� 5o  "    5p  &   �� 5q  *    64   �� *
IsSelected+ �� $
 Self=� true6~   �� 5r  *    64   �� *TabStripPlacement+ �� " �� Left6�   .0�5t  &   ��  �@K�ZIndex$ 1��6E   �� 5u  &    � ��$ 
-2,-2,0,-2q�6?   �� 5v  &   $ innerBorder��6-    �@J�Opacity$ 1Q�6Y   �� 5w  &   $ innerBorder��6-    � ��$ 1,1,0,1q�6a   �� 5x  &   $ 
mainBorder��6-    � ��$ 1,1,0,1q�6`   �� 5y  &   $ 	Seperator��6-    � y�$ 	Collapsed=�6Z   �� 5z  &   $ SeperatorTwo��6-    � y�$ 	Collapsed=�6]   �� 5}  &   $ CloseButton��6-    � y�$ Visible=�6\   5  #   ^� 5�  "    5�  &   �� 5�  *    64   �� *
IsSelected+ �� $
 Self=�	 false6~   �� 5�  *    64   �� *TabStripPlacement+ �� " ��
 Bottom6�   .0�5�  &   �� $ innerBorder��6-    � ��$ 1,0,1,1q�6a   �� 5�  &   $ 
mainBorder��6-    � ��$ 1,0,1,1q�6`   �� 5�  &   $ 	Seperator��6-    � y�$ Visible=�6Z   �� 5�  &   $ SeperatorTwo��6-    � y�$ Visible=�6]   �� 5�  &   $ CloseButton��6-    � y�$ 	Collapsed=�6\   �� 5�  &   $ 	LeftShape��6-    � ��
 ���� 6T   �� 5�  &   $ 	LeftShape��6-    � ��
 ���� 6V   �� 5�  &   $ 
RightShape��6-    � ��
 ���� 6U   �� 5�  &   $ 
RightShape��6-    � ��
 ���� 6W   5�  #   ^� 5�  "    5�  &   �� 5�  *    64   �� *
IsSelected+ �� $
 Self=� true6~   �� 5�  *    64   �� *TabStripPlacement+ �� " ��
 Bottom6�   .0�5�  &   ��  �@K�ZIndex$ 1��6E   �� 5�  &    � ��$ 
-2,0,-2,-2q�6?   �� 5�  &   $ innerBorder��6-    �@J�Opacity$ 1Q�6Y   �� 5�  &   $ innerBorder��6-    � ��$ 1,0,1,1q�6a   �� 5�  &   $ 
mainBorder��6-    � ��$ 1,0,1,1q�6`   �� 5�  &   $ 	Seperator��6-    � y�$ 	Collapsed=�6Z   �� 5�  &   $ SeperatorTwo��6-    � y�$ 	Collapsed=�6]   �� 5�  &   $ CloseButton��6-    � y�$ Visible=�6\   5�  #   ^� 5�  "    5�  &   �� 5�  *    64   �� *
IsSelected+ �� $
 Self=�	 false6~   �� 5�  *    64   �� *TabStripPlacement+ �� " ��	 Right6�   .0�5�  &   �� $ innerBorder��6-    � ��$ 0,1,1,1q�6a   �� 5�  &   $ 
mainBorder��6-    � ��$ 0,1,1,1q�6`   �� 5�  &   $ 	Seperator��6-    � y�$ Visible=�6Z   �� 5�  &   $ SeperatorTwo��6-    � y�$ Visible=�6]   �� 5�  &   $ CloseButton��6-    � y�$ 	Collapsed=�6\   �� 5�  &   $ 	LeftShape��6-    � ��
 ���� 6T   �� 5�  &   $ 	LeftShape��6-    � ��
 ���� 6V   �� 5�  &   $ 
RightShape��6-    � ��
 ���� 6U   �� 5�  &   $ 
RightShape��6-    � ��
 ���� 6W   5�  #   ^� 5�  "    5�  &   �� 5�  *    64   �� *
IsSelected+ �� $
 Self=� true6~   �� 5�  *    64   �� *TabStripPlacement+ �� " ��	 Right6�   .0�5�  &   ��  �@K�ZIndex$ 1��6E   �� 5�  &    � ��$ 
0,-2,-2,-2q�6?   �� 5�  &   $ innerBorder��6-    �@J�Opacity$ 1Q�6Y   �� 5�  &   $ innerBorder��6-    � ��$ 0,1,1,1q�6a   �� 5�  &   $ 
mainBorder��6-    � ��$ 0,1,1,1q�6`   �� 5�  &   $ 	Seperator��6-    � y�$ 	Collapsed=�6Z   �� 5�  &   $ SeperatorTwo��6-    � y�$ 	Collapsed=�6]   �� 5�  &   $ CloseButton��6-    � y�$ Visible=�6\   5�  #   ^� 5�  "    5�  &   �� 5�  *    64   �� *
IsSelected+ �� $
 Self=�	 false6~   �� 5�  *    64   �� *TabStripPlacement+ �� " �� Top6�   .0�5�  &   �� $ innerBorder��6-    � ��$ 1,1,1,0q�6a   �� 5�  &   $ 
mainBorder��6-    � ��$ 1,1,1,0q�6`   �� 5�  &   $ 	Seperator��6-    � y�$ Visible=�6Z   �� 5�  &   $ CloseButton��6-    � y�$ 	Collapsed=�6\   �� 5�  &   $ 	LeftShape��6-    � ��
 ���� 6T   �� 5�  &   $ 	LeftShape��6-    � ��
 ���� 6V   �� 5�  &   $ 
RightShape��6-    � ��
 ���� 6U   �� 5�  &   $ 
RightShape��6-    � ��
 ���� 6W   5�  #   ^� 5�  "    5�  &   �� 5�  *    64   �� *
IsSelected+ �� $
 Self=� true6~   �� 5�  *    64   �� *TabStripPlacement+ �� " �� Top6�   .0�5�  &   ��  �@K�ZIndex$ 1��6E   �� 5�  &    � ��$ 
-2,-2,-2,0q�6?   �� 5�  &   $ innerBorder��6-    �@J�Opacity$ 1Q�6Y   �� 5�  &   $ innerBorder��6-    � ��$ 1,1,1,0q�6a   �� 5�  &   $ 
mainBorder��6-    � ��$ 1,1,1,0q�6`   �� 5�  &   $ 	Seperator��6-    � y�$ 	Collapsed=�6Z   �� 5�  &   $ SeperatorTwo��6-    � y�$ 	Collapsed=�6]   �� 5�  &   $ CloseButton��6-    � y�$ Visible=�6\   5�  #   ]� 5�  "     5�  &   �� 5�  *   ! �@J�IsMouseOver$
 True��6K   �� 5�  *   ! �@��
IsSelected$ False��6J   ./�5�  &   �� $ CloseButton��6-    � y�$ Visible=�6\   �� 5�  &   $ 	Seperator��6-    � y�$ 	Collapsed=�6Z   �� 5�  &   $ SeperatorTwo��6-    � y�$ 	Collapsed=�6]   �� 5�  &   $ InactiveLine��6-    � y�$ Visible=�6]   �� 5�  &   $ IsSaved��6-    � y�$ 	Collapsed=�6X   �� 5�  &   $ 	LeftShape��6-   # �  6T    � ���� 5�  &   $ 	LeftShape��6-   # �  6V    � ���� 5�  &   $ 
RightShape��6-   # �  6U    � ���� 5�  &   $ 
RightShape��6-   # �  6W    � ��5�  #   �� 5�  "   $
" True��6J   # 6.   �� *	IsSaved+.a�5�  &   �� $ IsSaved��6-    � y�$ 	Collapsed=�6X   5�  #   �� 5�  "   $" False��6J   # 6.   �� *	IsSaved+.a�5�  &   �� $ CloseButton��6-    � y�$ Hidden=�6\   5   #   ]� 5  "     5  &   �� 5  *   ! �@J�IsMouseOver$
 True��6K   ./�5  &   �� $ IsSaved��6-    � y�$ 	Collapsed=�6X   �� 5  &   $ CloseButton��6-    � y�$ Visible=�6\   5
  #   5     5     5     5     5     