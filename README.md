# AntDesign.Avalonia
## Develop
* please use visaulstudio 2022 or greater or rider
* use .net7 runtime (version 7.0.100 or greater)(if you want to use others, please modify the version in the global.json)
* please setup workloads include Android, iOS, Wasm 
* please open the long path support in Windows OS(https://learn.microsoft.com/en-us/windows/win32/fileio/maximum-file-path-limitation?tabs=registry)

## Preview
![image](https://user-images.githubusercontent.com/28770378/230071873-7b20966b-b4fc-44bc-b95a-5f71bfcd2d66.png)
![image](https://user-images.githubusercontent.com/28770378/230072050-756fdfdf-1eb9-4d0b-9387-af4bf8e5ec39.png)
![image](https://user-images.githubusercontent.com/28770378/230071946-ed768bb2-e701-4e79-bb64-7000958ee28c.png)
![image](https://user-images.githubusercontent.com/28770378/230072189-50dad7ae-af08-4891-9c4c-d3be307fcb64.png)
![image](https://user-images.githubusercontent.com/28770378/230072321-bc44c29d-6710-45bf-8df7-353109ad1b72.png)
![image](https://user-images.githubusercontent.com/28770378/230072402-d9cd6925-7c66-40c2-9e16-53a7b94c064f.png)
![image](https://user-images.githubusercontent.com/28770378/230072486-91facdae-bc25-49a6-809b-f307b02321b1.png)
![image](https://user-images.githubusercontent.com/28770378/230072518-2974c5b7-4d6d-43c1-8b9a-638cfec50242.png)
![image](https://user-images.githubusercontent.com/28770378/230072606-02410c97-1e17-4331-85e9-80384248b913.png)

## Use AntDesign.Avalonia
1. Add [AntDesign.Avalonia][nuget] nuget package to your project:

       dotnet add package AntDesign.Avalonia

2. Edit `App.xaml` file:
   > If you install 1.0.0-* version or higher, use this:
   ```xaml
   <Application ...
     xmlns:themes="clr-namespace:AntDesign;assembly=AntDesign"
     ...>
     <Application.Styles>
       <AntDesign:AntDesign Coloring="None" IsRounded="True"/>
       <AntDesign:AntDesignDataGrid/>
       <AntDesign:AntDesignColorPicker/>
     </Application.Styles>
   </Application>
   ```
   ```CS
    
   ```
   > you can change ui global colour with Coloring Property:
  ```xaml
     <AntDesign:AntDesign Coloring="None" />
  ```
   > you can change global CornerRadius with IsRounded Property:
  ```xaml
     <AntDesign:AntDesign IsRounded="True" />
  ```

3. If you want to using AntDesign only , you can only add [AntDesign]
4. If you want to using AntDesign DataGrid only , you can only add [AntDesign.DataGrid]
5. If you want to using AntDesign ColorPicker only , you can only add [AntDesign.ColorPicker]
6. If you want to using Custom Fonts-Alibaba PuHuiTi(∞¢¿Ô∞Õ∞Õ∆’ª›ÃÂ) only , you can only add [Avalonia.Toolkit]