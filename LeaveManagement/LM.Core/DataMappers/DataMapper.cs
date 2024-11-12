using LM.Core.DTO;
using LM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Core
{
    public static class DataMapper
    {

        // ActionMaster
        public static ActionMasterModel ToModel(this ActionMaster actionMaster)
        {
            return new ActionMasterModel
            {
                actionMasterId = actionMaster.actionMasterId,
                roleId = actionMaster.roleId,
                actionId = actionMaster.actionId,
                updatedStatusId = actionMaster.updatedStatusId,
                actionName=actionMaster.actionName

            };
        }

        public static ActionMaster ToEntity(this ActionMasterModel actionMasterModel)
        {
            return new ActionMaster
            {
                actionMasterId = actionMasterModel.actionMasterId,
                roleId = actionMasterModel.roleId,
                actionId = actionMasterModel.actionId,
                updatedStatusId = actionMasterModel.updatedStatusId,
                actionName = actionMasterModel.actionName
            };
        }


        //Actions
        public static ActionsModel ToModel(this Actions actions)
        {
            return new ActionsModel
            {
                actionId = actions.actionId,
                actionName = actions.actionName
            };
        }

        public static Actions ToEntity(this ActionsModel actionsModel)
        {
            return new Actions
            {
                actionId = actionsModel.actionId,
                actionName = actionsModel.actionName
            };
        }


        //ApplicationStatus
        public static ApplicationStatusModel ToModel(this ApplicationStatus applicationStatus)
        {
            return new ApplicationStatusModel
            {
                statusId = applicationStatus.statusId,
                statusName = applicationStatus.statusName
            };
        }

        public static ApplicationStatus ToEntity(this ApplicationStatusModel applicationStatusModel)
        {
            return new ApplicationStatus
            {
                statusId = applicationStatusModel.statusId,
                statusName = applicationStatusModel.statusName
            };
        }


        //Departments
        public static DepartmentsModel ToModel(this Departments departments)
        {
            return new DepartmentsModel
            {
                dptId = departments.dptId,
                dptName = departments.dptName,
                location = departments.location,
                orgId = departments.orgId
            };
        }

        public static Departments ToEntity(this DepartmentsModel departmentsModel)
        {
            return new Departments
            {
                dptId = departmentsModel.dptId,
                dptName = departmentsModel.dptName,
                location = departmentsModel.location,
                orgId = departmentsModel.orgId
            };
        }


        //Employee
        public static EmployeesModel ToModel(this Employees employees)
        {
            return new EmployeesModel
            {
                empId = employees.empId,
                firstName = employees.firstName,
                lastName = employees.lastName,
                emailAddress = employees.emailAddress,
                birthDate = employees.birthDate,
                city = employees.city,
                createdAt = employees.createdAt,
                updatedAt = employees.updatedAt,
                userId = employees.userId,
                dptId = employees.dptId,
                costCenterId = employees.costCenterId,
                roleId = employees.roleId,
                managerId = employees.managerId,
                orgId = employees.orgId,


                dptName = employees.dptName,         
                location = employees.location,
                costCenterName = employees.costCenterName,
                roleName = employees.roleName,
                managerName = employees.managerName,
                orgName = employees.orgName

            };
        }

        public static Employees ToEntity(this EmployeesModel employeesModel)
        {
            return new Employees
            {
                empId = employeesModel.empId,
                firstName = employeesModel.firstName,
                lastName = employeesModel.lastName,
                emailAddress = employeesModel.emailAddress,
                birthDate = employeesModel.birthDate,
                city = employeesModel.city,
                createdAt = employeesModel.createdAt,
                updatedAt = employeesModel.updatedAt,
                userId = employeesModel.userId,
                dptId = employeesModel.dptId,
                costCenterId = employeesModel.costCenterId,
                roleId = employeesModel.roleId,
                managerId = employeesModel.managerId,
                orgId = employeesModel.orgId,

                //
                dptName = employeesModel.dptName,          
                location = employeesModel.location,
                costCenterName = employeesModel.costCenterName,
                roleName = employeesModel.roleName,
                managerName = employeesModel.managerName,
                orgName = employeesModel.orgName
            };
        }


        //LeaveApplications
        public static LeaveApplicationsModel ToModel(this LeaveApplications leaveApplications)
        {
            return new LeaveApplicationsModel
            {
                leaveId = leaveApplications.leaveId,
                leaveTypeId = leaveApplications.leaveTypeId,
                leaveDateFrom = leaveApplications.leaveDateFrom,
                leaveDateTo = leaveApplications.leaveDateTo,
                remark = leaveApplications.remark,
                statusId = leaveApplications.statusId,
                applicationDate = leaveApplications.applicationDate,
                updatedDate = leaveApplications.updatedDate,
                totalLeaves = leaveApplications.totalLeaves,
                empId = leaveApplications.empId,

                //
                firstName = leaveApplications.firstName,
                lastName = leaveApplications.lastName,
                statusName = leaveApplications.statusName,
                leaveType = leaveApplications.leaveType


            };
        }

        public static LeaveApplications ToEntity(this LeaveApplicationsModel leaveApplicationsModel)
        {
            return new LeaveApplications
            {
                leaveId = leaveApplicationsModel.leaveId,
                leaveTypeId = leaveApplicationsModel.leaveTypeId,
                leaveDateFrom = leaveApplicationsModel.leaveDateFrom,
                leaveDateTo = leaveApplicationsModel.leaveDateTo,
                remark = leaveApplicationsModel.remark,
                statusId = leaveApplicationsModel.statusId,
                applicationDate = leaveApplicationsModel.applicationDate,
                updatedDate = leaveApplicationsModel.updatedDate,
                totalLeaves = leaveApplicationsModel.totalLeaves,
                empId = leaveApplicationsModel.empId,

                //
                firstName = leaveApplicationsModel.firstName,
                lastName = leaveApplicationsModel.lastName,
                statusName = leaveApplicationsModel.statusName,
                leaveType = leaveApplicationsModel.leaveType
            };
        }


        //LeaveBalances
        public static LeaveBalancesModel ToModel(this LeaveBalances leaveBalances)
        {
            return new LeaveBalancesModel
            {
                leaveBalanceId = leaveBalances.leaveBalanceId,
                empId = leaveBalances.empId,
                leaveTypeId = leaveBalances.leaveTypeId,
                openingBalance = leaveBalances.openingBalance,
                currentBalance = leaveBalances.currentBalance
            };
        }

        public static LeaveBalances ToEntity(this LeaveBalancesModel leaveBalancesModel)
        {
            return new LeaveBalances
            {
                leaveBalanceId = leaveBalancesModel.leaveBalanceId,
                empId = leaveBalancesModel.empId,
                leaveTypeId = leaveBalancesModel.leaveTypeId,
                openingBalance = leaveBalancesModel.openingBalance,
                currentBalance = leaveBalancesModel.currentBalance,
                leaveType=leaveBalancesModel.leaveType
            };
        }


        //LeaveTypes
        public static LeaveTypesModel ToModel(this LeaveTypes leaveTypes)
        {
            return new LeaveTypesModel
            {
                leaveTypeId = leaveTypes.leaveTypeId,
                leaveType = leaveTypes.leaveType,
                createdAt = leaveTypes.createdAt,
                updatedAt = leaveTypes.updatedAt,
                createdBy = leaveTypes.createdBy,
                updatedBy = leaveTypes.updatedBy
            };
        }

        public static LeaveTypes ToEntity(this LeaveTypesModel leaveTypesModel)
        {
            return new LeaveTypes
            {
                leaveTypeId = leaveTypesModel.leaveTypeId,
                leaveType = leaveTypesModel.leaveType,
                createdAt = leaveTypesModel.createdAt,
                updatedAt = leaveTypesModel.updatedAt,
                createdBy = leaveTypesModel.createdBy,
                updatedBy = leaveTypesModel.updatedBy
            };
        }


        //MenuAccessMaster
        public static MenuAccessMasterModel ToModel(this MenuAccessMaster menuAccessMaster)
        {
            return new MenuAccessMasterModel
            {
                accessMasterId = menuAccessMaster.accessMasterId,
                roleId = menuAccessMaster.roleId,
                menuId = menuAccessMaster.menuId
            };
        }

        public static MenuAccessMaster ToEntity(this MenuAccessMasterModel menuAccessMasterModel)
        {
            return new MenuAccessMaster
            {
                accessMasterId = menuAccessMasterModel.accessMasterId,
                roleId = menuAccessMasterModel.roleId,
                menuId = menuAccessMasterModel.menuId
            };
        }


        //Menus
        public static MenusModel ToModel(this Menus menus)
        {
            return new MenusModel
            {
                menuId = menus.menuId,
                menuName = menus.menuName,
                url = menus.url
            };
        }

        public static Menus ToEntity(this MenusModel menusModel)
        {
            return new Menus
            {
                menuId = menusModel.menuId,
                menuName = menusModel.menuName,
                url = menusModel.url
            };
        }


        //Organisations
        public static OrganisationsModel ToModel(this Organisations organisations)
        {
            return new OrganisationsModel
            {
                orgId = organisations.orgId,
                name = organisations.name
            };
        }

        public static Organisations ToEntity(this OrganisationsModel organisationsModel)
        {
            return new Organisations
            {
                orgId = organisationsModel.orgId,
                name = organisationsModel.name
            };
        }


        //Process
        public static ProcessModel ToModel(this Process process)
        {
            return new ProcessModel
            {
                processId = process.processId,
                processName = process.processName,
                createdAt = process.createdAt,
                updatedAt = process.updatedAt,
                CreatedBy = process.CreatedBy,
                UpdatedBy = process.UpdatedBy
            };
        }

        public static Process ToEntity(this ProcessModel processModel)
        {
            return new Process
            {
                processId = processModel.processId,
                processName = processModel.processName,
                createdAt = processModel.createdAt,
                updatedAt = processModel.updatedAt,
                CreatedBy = processModel.CreatedBy,
                UpdatedBy = processModel.UpdatedBy
            };
        }


        //ProcessMaster
        public static ProcessMasterModel ToModel(this ProcessMaster processMaster)
        {
            return new ProcessMasterModel
            {
                processMasterId = processMaster.processMasterId,
                applicationType = processMaster.applicationType,
                processId = processMaster.processId
            };
        }

        public static ProcessMaster ToEntity(this ProcessMasterModel processMasterModel)
        {
            return new ProcessMaster
            {
                processMasterId = processMasterModel.processMasterId,
                applicationType = processMasterModel.applicationType,
                processId = processMasterModel.processId
            };
        }


        //ProcessStages
        public static ProcessStagesModel ToModel(this ProcessStages processStages)
        {
            return new ProcessStagesModel
            {
                nextStageId = processStages.nextStageId,
                stageId = processStages.stageId,
                stageName = processStages.stageName,
                stageStatus = processStages.stageStatus,
                performedByRoleId = processStages.performedByRoleId,
                processId = processStages.processId
            };
        }

        public static ProcessStages ToEntity(this ProcessStagesModel processStagesModel)
        {
            return new ProcessStages
            {
                nextStageId = processStagesModel.nextStageId,
                stageId = processStagesModel.stageId,
                stageName = processStagesModel.stageName,
                stageStatus = processStagesModel.stageStatus,
                performedByRoleId = processStagesModel.performedByRoleId,
                processId = processStagesModel.processId
            };
        }


        //PublicHolidays
        public static PublicHolidaysModel ToModel(this PublicHolidays publicHolidays)
        {
            return new PublicHolidaysModel
            {
                holidayId = publicHolidays.holidayId,
                holidayDate = publicHolidays.holidayDate,
                holidayInfo = publicHolidays.holidayInfo,
                orgId = publicHolidays.orgId
            };
        }

        public static PublicHolidays ToEntity(this PublicHolidaysModel publicHolidaysModel)
        {
            return new PublicHolidays
            {
                holidayId = publicHolidaysModel.holidayId,
                holidayDate = publicHolidaysModel.holidayDate,
                holidayInfo = publicHolidaysModel.holidayInfo,
                orgId = publicHolidaysModel.orgId
            };
        }


        //UserRoles
        public static UserRolesModel ToModel(this UserRoles userRoles)
        {
            return new UserRolesModel
            {
                roleId = userRoles.roleId,
                roleName = userRoles.roleName,
                createdAt = userRoles.createdAt,
                updatedAt = userRoles.updatedAt,
                createdBy = userRoles.createdBy,
                updatedBy = userRoles.updatedBy,
                createdByName=userRoles.createdByName,
                updatedByName=userRoles.updatedByName
            };
        }

        public static UserRoles ToEntity(this UserRolesModel userRolesModel)
        {
            return new UserRoles
            {
                roleId = userRolesModel.roleId,
                roleName = userRolesModel.roleName,
                createdAt = userRolesModel.createdAt,
                updatedAt = userRolesModel.updatedAt,
                createdBy = userRolesModel.createdBy,
                updatedBy = userRolesModel.updatedBy,
                createdByName = userRolesModel.createdByName,
                updatedByName = userRolesModel.updatedByName
            };
        }


        //Users
        public static UsersModel ToModel(this Users users)
        {
            return new UsersModel
            {
                userId = users.userId,
                userName = users.userName,
                password = users.password,
                isActive = users.isActive,
                createdAt = users.createdAt,
                updatedAt = users.updatedAt,
                createdBy = users.createdBy,
                updatedBy = users.updatedBy,
                roleName=users.roleName
            };
        }

        public static Users ToEntity(this UsersModel usersModel)
        {
            return new Users
            {
                userId = usersModel.userId,
                userName = usersModel.userName,
                password = usersModel.password,
                isActive = usersModel.isActive,
                createdAt = usersModel.createdAt,
                updatedAt = usersModel.updatedAt,
                createdBy = usersModel.createdBy,
                updatedBy = usersModel.updatedBy,
                roleName = usersModel.roleName
            };
        }


        //CostCenter
        public static CostCentersModel ToModel(this CostCenters costCenters)
        {
            return new CostCentersModel
            {
                costCenterId = costCenters.costCenterId,
                costCenterName = costCenters.costCenterName,
                orgId = costCenters.orgId
            };
        }

        public static CostCenters ToEntity(this CostCentersModel costCentersModel)
        {
            return new CostCenters
            {
                costCenterId = costCentersModel.costCenterId,
                costCenterName = costCentersModel.costCenterName,
                orgId = costCentersModel.orgId
            };
        }


    }
}
