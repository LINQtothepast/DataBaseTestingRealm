   M S B A M L   `   `   `  ����M  IDatabaseTestingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:DatabaseTestingAppDatabaseTestingApp  5   	   #    DatabaseTestingApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:DatabaseTestingApp     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ PlayerListBox��5
         SelectionMode$ Single=�6+      SelectionUnit$
 Cell=�6B   $��	10,10,0,0q�6W   $	��Top=�6j   $	��279��6�   $
��Left=�6�   $	��271��6�   �� 5   
   -   5         ��Name$ Username��5      $	��N/A��6"   $
��Left=�60   $��	389,8,0,0q�6K   $	��Top=�6^   $��83��6v   �� 5   
   -   5         ��Name$ ArmedButton��5      $��Set Armed to 1��6&   $
��Left=�6?   $��315,229,0,0q�6Z   $	��Top=�6o   $	��157��6�   6�   �� 5   
   -   5        $ 
BardButton��5      $��Bard Role Goes��6%   $
��Left=�6>   $��315,253,0,0q�6Y   $	��Top=�6n   $	��157��6�   6�   �� 5   
   -   5        $
 Role��5      $	��N/A��6   $
��Left=�6,   $��
389,39,0,0q�6G   $	��Top=�6[   $��83��6s   �� 5   
   -   5        $ Armed��5      $	��N/A��6   $
��Left=�6-   $��
389,70,0,0q�6H   $	��Top=�6\   $��83��6t   �� 5   
   -   5        $ 
ArmedLabel��5      $��Armed:��6$   $
��Left=�65   $��
315,70,0,0q�6P   $	��Top=�6d   �� 5   
   -   5        $ 	RoleLabel��5      $��Role:��6#   $
��Left=�63   $��
315,39,0,0q�6N   $	��Top=�6b   �� 5   
   -	   5        $ UsernameLabel��5      $��	Username:��6'   $
��Left=�6;   $��	315,8,0,0q�6V   $	��Top=�6i   �� 5   
   -
   5        $ BlockedLabel��5      $��Blocked��6&   $
��Left=�68   $��315,101,0,0q�6S   $	��Top=�6h   �� 5   
   -   5        $ Blocked��5      $	��N/A��6!   $
��Left=�6/   $��389,101,0,0q�6J   $	��Top=�6_   $��83��6w   �� 5   
   -   5        $ VisitedByLabel��5      $��Visited By:��6(   $
��Left=�6>   $��315,132,0,0q�6Y   $	��Top=�6n   �� 5   
   -   5        $ 	VisitedBy��5      $	��N/A��6#   $
��Left=�61   $��389,132,0,0q�6L   $	��Top=�6a   $��83��6y   �� 5   
   -   5        $ ResetStatusButton��5      $��Reset Status Values��6,   $
��Left=�6J   $��
10,294,0,0q�6e   $	��Top=�6y   $	��113��6�   6�   �� 5   
   -   5        $ 
UserValues��5      $��Passed User Values��6%   $
��Left=�6B   $��315,277,0,0q�6]   $	��Top=�6r   $	��157��6�   6�   �� 5   
   -   5        $ ResetVotesValues��5      $��Reset Vote Values��6+   $
��Left=�6G   $��173,294,0,0q�6b   $	��Top=�6w   $	��108��6�   6�   5      5      