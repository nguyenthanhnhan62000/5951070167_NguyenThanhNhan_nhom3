using System;
using System.Reflection;

namespace _5951071067_NguyenThanhNhan_nhom3.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}