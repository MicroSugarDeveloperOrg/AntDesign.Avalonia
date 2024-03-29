﻿namespace AntDesign.Extensions;
public static class Classes
{
    static Classes()
    {
        errorProperty.Changed.AddClassHandler<Control, bool>((s, e) => s.Classes.Set(_errorClass, e.NewValue.Value));
        endProperty.Changed.AddClassHandler<Control, bool>((s, e) => s.Classes.Set(_endClass, e.NewValue.Value));
        groupProperty.Changed.AddClassHandler<Control, bool>((s, e) => s.Classes.Set(_groupClass, e.NewValue.Value));
        leftProperty.Changed.AddClassHandler<Control, bool>((s, e) => s.Classes.Set(_leftClass, e.NewValue.Value));
        centerProperty.Changed.AddClassHandler<Control, bool>((s, e) => s.Classes.Set(_centerClass, e.NewValue.Value));
        rightProperty.Changed.AddClassHandler<Control, bool>((s, e) => s.Classes.Set(_rightClass, e.NewValue.Value));
        roundProperty.Changed.AddClassHandler<Control, bool>((s, e) => s.Classes.Set(_roundClass, e.NewValue.Value));
        dangerProperty.Changed.AddClassHandler<Control, bool>((s, e) => s.Classes.Set(_dangerClass, e.NewValue.Value));
        removeProperty.Changed.AddClassHandler<Control, bool>((s, e) => s.Classes.Set(_removeClass, e.NewValue.Value));
        titleProperty.Changed.AddClassHandler<Control, bool>((s, e) => s.Classes.Set(_titleClass, e.NewValue.Value));
        topProperty.Changed.AddClassHandler<Control, bool>((s, e) => s.Classes.Set(_topClass, e.NewValue.Value));
        middleProperty.Changed.AddClassHandler<Control, bool>((s, e) => s.Classes.Set(_middleClass, e.NewValue.Value));
        bottomProperty.Changed.AddClassHandler<Control, bool>((s, e) => s.Classes.Set(_bottomClass, e.NewValue.Value));
    }

    private const string _errorClass = "error";
    private const string _endClass = "end";
    private const string _groupClass = "group";
    private const string _leftClass = "left";
    private const string _centerClass = "center";
    private const string _rightClass = "right";
    private const string _topClass = "top";
    private const string _middleClass = "middle";
    private const string _bottomClass = "bottom";
    private const string _roundClass = "round";
    private const string _dangerClass = "danger";
    private const string _removeClass = "remove";
    private const string _titleClass = "title";
    
    public static readonly StyledProperty<bool> errorProperty = AvaloniaProperty.RegisterAttached<Control, bool>(_errorClass, typeof(Classes));
    public static void Seterror(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(errorProperty, value);
    public static bool Geterror(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(errorProperty);

    public static readonly StyledProperty<bool> endProperty = AvaloniaProperty.RegisterAttached<Control, bool>(_endClass, typeof(Classes));
    public static void Setend(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(endProperty, value);
    public static bool Getend(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(endProperty);

    public static readonly StyledProperty<bool> groupProperty = AvaloniaProperty.RegisterAttached<Control, bool>(_groupClass, typeof(Classes));
    public static void Setgroup(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(groupProperty, value);
    public static bool Getgroup(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(groupProperty);

    public static readonly StyledProperty<bool> leftProperty = AvaloniaProperty.RegisterAttached<Control, bool>(_leftClass, typeof(Classes));
    public static void Setleft(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(leftProperty, value);
    public static bool Getleft (AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(leftProperty);

    public static readonly StyledProperty<bool> centerProperty = AvaloniaProperty.RegisterAttached<Control, bool>(_centerClass, typeof(Classes));
    public static void Setcenter(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(centerProperty, value);
    public static bool Getcenter(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(centerProperty);

    public static readonly StyledProperty<bool> rightProperty = AvaloniaProperty.RegisterAttached<Control, bool>(_rightClass, typeof(Classes));
    public static void Setright(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(rightProperty, value);
    public static bool Getright(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(rightProperty);

    public static readonly StyledProperty<bool> roundProperty = AvaloniaProperty.RegisterAttached<Control, bool>(_roundClass, typeof(Classes));
    public static void Setround(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(roundProperty, value);
    public static bool Getround(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(roundProperty);

    public static readonly StyledProperty<bool> dangerProperty = AvaloniaProperty.RegisterAttached<Control, bool>(_dangerClass, typeof(Classes));
    public static void Setdanger(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(dangerProperty, value);
    public static bool Getdanger(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(dangerProperty);

    public static readonly StyledProperty<bool> removeProperty = AvaloniaProperty.RegisterAttached<Control, bool>(_removeClass, typeof(Classes));
    public static void Setremove(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(removeProperty, value);
    public static bool Getremove(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(removeProperty);

    public static readonly StyledProperty<bool> titleProperty = AvaloniaProperty.RegisterAttached<Control, bool>(_titleClass, typeof(Classes));
    public static void Settitle(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(titleProperty, value);
    public static bool Gettitle(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(titleProperty);

    public static readonly StyledProperty<bool> topProperty = AvaloniaProperty.RegisterAttached<Control, bool>(_topClass, typeof(Classes));
    public static void Settop(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(topProperty, value);
    public static bool Gettop(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(topProperty);

    public static readonly StyledProperty<bool> middleProperty = AvaloniaProperty.RegisterAttached<Control, bool>(_middleClass, typeof(Classes));
    public static void Setmiddle(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(middleProperty, value);
    public static bool Getmiddle(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(middleProperty);

    public static readonly StyledProperty<bool> bottomProperty = AvaloniaProperty.RegisterAttached<Control, bool>(_bottomClass, typeof(Classes));
    public static void Setbottom(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(bottomProperty, value);
    public static bool Getbottom(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(bottomProperty);
}
