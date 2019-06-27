import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { TableQueryComponentBase } from '../../../util';
import { ModuleQuery } from './model/module-query';
import { ModuleViewModel } from './model/module-view-model';
import { ApplicationViewModel } from "../application/model/application-view-model";

/**
 * 模块列表页
 */
@Component( {
    selector: 'module-list',
    templateUrl: !env.dev() ? './html/index.component.html' : '/view/systems/module'
} )
export class ModuleListComponent extends TableQueryComponentBase<ModuleViewModel, ModuleQuery>  {
    /**
     * 当前应用程序
     */
    selectedApplication: ApplicationViewModel;

    /**
     * 初始化模块列表页
     * @param injector 注入器
     */
    constructor( injector: Injector ) {
        super( injector );
        this.selectedApplication = new ApplicationViewModel();
    }

    /**
     * 选择应用程序
     * @param application 应用程序
     */
    selectApplication( application: ApplicationViewModel ) {
        this.selectedApplication = application;
        this.queryParam.applicationId = application.id;
        this.query();
    }
}