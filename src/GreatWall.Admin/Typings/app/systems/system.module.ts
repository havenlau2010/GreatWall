import { NgModule } from '@angular/core';
import { FrameworkModule } from '../framework.module';
import { SystemRoutingModule } from './system-routing.module';
import { ApplicationListComponent } from './application/application-list.component';
import { ApplicationEditComponent } from './application/application-edit.component';
import { ApplicationDetailComponent } from './application/application-detail.component';
import { UserListComponent } from './user/user-list.component';
import { UserCreateComponent } from './user/user-create.component';
import { UserDetailComponent } from './user/user-detail.component';
import { RoleListComponent } from './role/role-list.component';
import { RoleEditComponent } from './role/role-edit.component';
import { RoleDetailComponent } from './role/role-detail.component';

/**
 * 系统模块
 */
@NgModule( {
    declarations: [
        ApplicationListComponent, ApplicationEditComponent, ApplicationDetailComponent,
        UserListComponent, UserCreateComponent, UserDetailComponent,
        RoleListComponent, RoleEditComponent, RoleDetailComponent,
    ],
    imports: [
        FrameworkModule, SystemRoutingModule
    ]
} )
export class SystemModule {
}