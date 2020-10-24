import bpy
import os

x = 0
    
while (os.path.exists("C:\\Users\\johns\\Documents\\3d_model\\sketchup-export\\sketchup-export_"+str(x)+".dae")):

    for material in bpy.data.materials:
        material.user_clear()
        bpy.data.materials.remove(material)

    bpy.ops.object.mode_set(mode='OBJECT')
    bpy.ops.object.select_all(action='SELECT')
    bpy.ops.object.delete(use_global=False)

    bpy.ops.wm.collada_import(filepath = "C:\\Users\\johns\\Documents\\3d_model\\sketchup-export\\sketchup-export_"+str(x)+".dae")

    bpy.ops.object.select_all(action='SELECT')
    bpy.context.scene.objects.active = bpy.context.scene.objects[0]
    bpy.ops.object.join()

    bpy.context.object.data.show_double_sided = False
    bpy.ops.mesh.uv_texture_add()
    bpy.ops.object.mode_set(mode='EDIT')
    bpy.ops.mesh.select_all(action='SELECT')
    bpy.ops.uv.smart_project(angle_limit=66, island_margin=0, user_area_weight=0)
    bpy.ops.uv.select_all(action='SELECT')
    bpy.ops.uv.average_islands_scale() 
    bpy.ops.uv.pack_islands(margin=0.02)
    bpy.ops.object.mode_set(mode='OBJECT')
    
    #bpy.ops.export_scene.fbx(filepath="C:\\Users\\johns\\Documents\\3d_model\\blender-export\\blender-export_"+str(x)+".fbx", global_scale=100.00, axis_forward='-Z', axis_up='Y',object_types={'MESH'}, use_mesh_modifiers=True, mesh_smooth_type='FACE',use_mesh_edges=False, use_armature_deform_only=False, use_anim=False, use_anim_action_all=False, use_default_take=False, use_anim_optimize=False, anim_optimize_precision=6.0, path_mode='AUTO', batch_mode='OFF', use_batch_own_dir=True, use_metadata=True)
    bpy.ops.wm.collada_export(filepath="C:\\Users\\johns\\Documents\\3d_model\\blender-export\\blender-export_"+str(x)+".dae")

    x = x + 1
    