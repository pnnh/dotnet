尝试通过CMake来生成C#工程

### 说明

在生成之前需要在CMakeLists.txt中启用C#语言，需注意C#仅支持生成Visual Studio工程文件

```cmake
cmake_minimum_required(VERSION 3.28...3.31)

# 通过项目指令启用C#
project(Gliese VERSION 0.1.0 LANGUAGES C CXX CSharp)

# 或者通过enable语句开启C#
enable_language(CSharp)
```

然后可以通过add_library来添加C#的工程文件

```cmake
add_library(Molecule SHARED Helpers/EnumHelper.cs)
```

之后需要配置目标属性，标记为C#工程，并可以设置工程配置

```cmake
set_target_properties(Molecule PROPERTIES
    DOTNET_SDK "Microsoft.NET.Sdk"
    DOTNET_TARGET_FRAMEWORK "net8.0"
    VS_GLOBAL_ImplicitUsings "enable"
    VS_GLOBAL_Nullable "enable"
    VS_GLOBAL_NullableReferenceTypes "true"
    VS_GLOBAL_TreatWarningsAsErrors "true")
```

### 添加Nuget依赖包和程序集引用

通过以上配置便可以执行cmake语句生成C#工程文件了

但是如果要添加第三方Nuget包和程序集引用还需要添加以下语句：

#### 添加Nuget包

```cmake
LIST(APPEND VS_PACKAGE_REFERENCES "SimpleBase_4.0.0")
LIST(APPEND VS_PACKAGE_REFERENCES "Base62_1.3.0")
LIST(APPEND VS_PACKAGE_REFERENCES "IdGen_3.0.3")
set_property(TARGET Molecule PROPERTY VS_PACKAGE_REFERENCES ${VS_PACKAGE_REFERENCES})
```

#### 添加程序集引用

```cmake
LIST(APPEND VS_DOTNET_REFERENCES "System")
LIST(APPEND VS_DOTNET_REFERENCES "System.Runtime")
LIST(APPEND VS_DOTNET_REFERENCES "Microsoft.AspNetCore.Mvc.Core")
set_property(TARGET Molecule PROPERTY VS_DOTNET_REFERENCES ${VS_DOTNET_REFERENCES})
```

### 生成项目文件

```bash
mkdir build && cd build
cmake ..
```

生成的.csproj工程文件和.sln解决方案文件在build目录下
