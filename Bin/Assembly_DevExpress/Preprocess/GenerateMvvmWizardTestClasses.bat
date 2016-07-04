copy nunit.framework.dll %~p1\
copy DevExpress.Printing.v*.Core.dll %~p1\
copy DevExpress.Data.v*.dll %~p1\
copy DevExpress.Mvvm.v*.dll %~p1\
copy DevExpress.Xpf.Core.v*.dll %~p1\
copy DevExpress.Design.v*.dll %~p1\
copy DevExpress.CodeConverter.v*.dll %~p1\
copy DevExpress.CodeParser.v*.dll %~p1\
copy DevExpress.Images.v*.dll %~p1\
copy DevExpress.Xpf.Grid.v*.dll %~p1\
copy DevExpress.Xpf.LayoutControl.v*.dll %~p1\
copy MetaSharp.dll %~p1\
nunit-console-x86-FW4 %1 /noshadow /xml=MvvmWizardsTestClasses.TestResult.xml
nunit-console-x86-FW4 %2 /noshadow /xml=SamplesGenerator.TestResult.xml