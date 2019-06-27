import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { EditComponentBase } from '../../../util';
import { ModuleViewModel } from './model/module-view-model';

/**
 * 模块编辑页
 */
@Component({
    selector: 'module-edit',
    templateUrl: !env.dev() ? './html/edit.component.html' : '/view/systems/module/edit'
})
export class ModuleEditComponent extends EditComponentBase<ModuleViewModel> {
    /**
     * 初始化模块编辑页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }

    /**
     * 获取基地址
     */
    protected getBaseUrl() {
        return "module";
    }
}