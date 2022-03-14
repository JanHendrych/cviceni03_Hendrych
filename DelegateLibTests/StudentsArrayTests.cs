using Microsoft.VisualStudio.TestTools.UnitTesting;
using DelegateLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DelegateLib.Tests;

[TestClass()]
public class StudentsArrayTests
{
    [TestMethod()]
    public void TestThatSortHasADelegateParameter()
    {
        Type? classType = Assembly.Load("DelegateLib").GetType("DelegateLib.StudentsArray");
        //Type classType = typeof(StudentsArray);
        Assert.IsNotNull(classType);
        MethodInfo? sortMethodInfo = classType.GetMethod("Sort");
        Assert.IsNotNull(sortMethodInfo);

        ParameterInfo[] sortMethodParameters = sortMethodInfo.GetParameters();
        Assert.IsNotNull(sortMethodParameters);
        Assert.AreEqual(1, sortMethodParameters.Length);

        ParameterInfo delegateParameter = sortMethodParameters[0];
        Assert.IsTrue(delegateParameter.ParameterType.IsSubclassOf(typeof(Delegate)));

        Type delegateType = delegateParameter.ParameterType;

        MethodInfo? invokeMethod = delegateType.GetMethod("Invoke");
        Assert.IsNotNull(invokeMethod);

        int studentParamsCount = 0;
        foreach (var item in invokeMethod.GetParameters())
            if (item.ParameterType.Name == "Student")
                studentParamsCount++;

        Assert.AreEqual(2, studentParamsCount);
    }

}
