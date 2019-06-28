import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ApplicationListComponent } from './application/application-list.component';
import { UserListComponent } from './user/user-list.component';
import { RoleListComponent } from './role/role-list.component';
import { ModuleListComponent } from './module/module-list.component';
import { ModuleEditComponent } from './module/module-edit.component';
import { ModuleDetailComponent } from './module/module-detail.component';

//路由配置
const routes: Routes = [
    {
        path: '',
        children: [
            { path: 'application', component: ApplicationListComponent },
            { path: 'user', component: UserListComponent },
            { path: 'role', component: RoleListComponent },
            {
                path: 'module', children: [
                    { path: '', component: ModuleListComponent },
                    { path: 'create', component: ModuleEditComponent },
                    { path: 'edit/:id', component: ModuleEditComponent },
                    { path: 'detail/:id', component: ModuleDetailComponent }
                ]
            }
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