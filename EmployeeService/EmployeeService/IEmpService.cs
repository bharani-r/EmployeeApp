using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IEmpService
    {
        [OperationContract]
        List<EmployeeDetail> GetAllEmp();
        [OperationContract]
        EmployeeDetail GetAllUserById(int empId);
        [OperationContract]
        int AddEmp(Employee emp);
        [OperationContract]
        int UpdateEmp(Employee emp);
        [OperationContract]
        int DeleteEmp(int empid);

        
        // TODO: Add your service operations here
    }

    
   
}
