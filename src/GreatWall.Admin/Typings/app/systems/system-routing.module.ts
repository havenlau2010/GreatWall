import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ApplicationListComponent } from './application/application-list.component';
import { UserListComponent } from './user/user-list.component';
import { UserCreateComponent } from './user/user-create.component';
import { UserDetailComponent } from './user/user-detail.component';
import { RoleListComponent } from './role/role-list.component';
import { RoleEditComponent } from './role/role-edit.component';
import { RoleDetailComponent } from './role/role-detail.component';
import { ModuleListComponent } from './module/module-list.component';
import { ModuleEditComponent } from './module/module-edit.component';
import { ModuleDetailComponent } from './module/module-detail.component';

//路由配置
const routes: Routes = [
    {
        path: '',
        children: [
            { path: 'application', component: ApplicationListComponent },
            {
                path: 'user',
                children: [
                    { path: '', component: UserListComponent },
                    { path: 'create', component: UserCreateComponent },
                    { path: 'detail/:id', component: UserDetailComponent }
                ]
            },
            {
                path: 'role', children: [
                    { path: '', component: RoleListComponent },
                    { path: 'create', component: RoleEditComponent },
                    { path: 'edit/:id', component: RoleEditComponent },
                    { path: 'detail/:id', component: RoleDetailComponent }
                ]
            },
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