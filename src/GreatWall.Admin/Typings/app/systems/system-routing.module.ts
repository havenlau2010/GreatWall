import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OidcAuthorize as Authorize } from "../../util";
import { ApplicationListComponent } from './application/application-list.component';
import { UserListComponent } from './user/user-list.component';
import { RoleListComponent } from './role/role-list.component';
import { ModuleListComponent } from './module/module-list.component';

//路由配置
const routes: Routes = [
    {
        path: '',
        children: [
            { path: 'application', component: ApplicationListComponent, canActivate: [Authorize] },
            { path: 'user', component: UserListComponent },
            { path: 'role', component: RoleListComponent },
            { path: 'module', component: ModuleListComponent }
        ]
    }
];

/**
 * 系统路由模块
 */
@NgModule( {
    imports: [RouterModule.forChild( routes )]
} )
export class SystemRoutingModule { }