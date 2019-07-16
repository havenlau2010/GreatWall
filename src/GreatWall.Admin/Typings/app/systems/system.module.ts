import { NgModule } from '@angular/core';
import { FrameworkModule } from '../framework.module';
import { SystemRoutingModule } from './system-routing.module';
import { ClaimListComponent } from './claim/claim-list.component';
import { ClaimEditComponent } from './claim/claim-edit.component';
import { ApplicationListComponent } from './application/application-list.component';
import { ApplicationEditComponent } from './application/application-edit.component';
import { ApplicationDetailComponent } from './application/application-detail.component';
import { ApplicationSelectComponent } from './application/application-select.component';
import { UserListComponent } from './user/user-list.component';
import { UserCreateComponent } from './user/user-create.component';
import { UserDetailComponent } from './user/user-detail.component';
import { RoleListComponent } from './role/role-list.component';
import { RoleEditComponent } from './role/role-edit.component';
import { RoleDetailComponent } from './role/role-detail.component';
import { RoleUserListComponent } from './role/role-user-list.component';
import { SelectUserListComponent } from './role/select-user-list.component';
import { PermissionComponent } from './role/permission.component';
import { ModuleListComponent } from './module/module-list.component';
import { ModuleEditComponent } from './module/module-edit.component';
import { ModuleDetailComponent } from './module/module-detail.component';
import { ModuleSelectComponent } from './module/module-select.component';

/**
 * 系统模块
 */
@NgModule( {
    declarations: [
        ClaimListComponent, ClaimEditComponent,
        ApplicationListComponent, ApplicationEditComponent, ApplicationDetailComponent, ApplicationSelectComponent,
        UserListComponent, UserCreateComponent, UserDetailComponent,
        RoleListComponent, RoleEditComponent, RoleDetailComponent, RoleUserListComponent,
        SelectUserListComponent, PermissionComponent,
        ModuleListComponent, ModuleEditComponent, ModuleDetailComponent, ModuleSelectComponent
    ],
    imports: [
        FrameworkModule, SystemRoutingModule
    ],
    entryComponents: [
        ClaimEditComponent,
        ApplicationEditComponent, ApplicationDetailComponent,
        UserCreateComponent, UserDetailComponent,
        RoleEditComponent, RoleDetailComponent, RoleUserListComponent,
        SelectUserListComponent, PermissionComponent,
        ModuleEditComponent, ModuleDetailComponent, ModuleSelectComponent
    ]
} )
export class SystemModule {
}