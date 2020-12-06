	.section	__TEXT,__text,regular,pure_instructions
	.macosx_version_min 10, 12
	.globl	_step
	.p2align	4, 0x90
_step:                                  ## @step
	.cfi_startproc
## BB#0:
	pushq	%rbp
Lcfi0:
	.cfi_def_cfa_offset 16
Lcfi1:
	.cfi_offset %rbp, -16
	movq	%rsp, %rbp
Lcfi2:
	.cfi_def_cfa_register %rbp
	subq	$32, %rsp
	movq	_nblocks@GOTPCREL(%rip), %rax
	movq	_history@GOTPCREL(%rip), %rcx
	movw	$1, -6(%rbp)
	movq	(%rcx), %rcx
	movzwl	_steps(%rip), %edx
	movzwl	(%rax), %esi
	imull	%esi, %edx
	movslq	%edx, %rax
	movq	(%rcx,%rax,8), %rax
	movq	%rax, -24(%rbp)
	movw	$0, -10(%rbp)
LBB0_1:                                 ## =>This Inner Loop Header: Depth=1
	movq	_nblocks@GOTPCREL(%rip), %rax
	movzwl	-10(%rbp), %ecx
	movzwl	(%rax), %edx
	cmpl	%edx, %ecx
	jge	LBB0_6
## BB#2:                                ##   in Loop: Header=BB0_1 Depth=1
	movq	_blocks@GOTPCREL(%rip), %rax
	movq	(%rax), %rcx
	movzwl	-10(%rbp), %edx
	movl	%edx, %esi
	movw	(%rcx,%rsi,2), %di
	movq	-24(%rbp), %rcx
	movzwl	-10(%rbp), %edx
	movl	%edx, %esi
	movw	%di, (%rcx,%rsi,2)
	movq	(%rax), %rax
	movzwl	-10(%rbp), %edx
	movl	%edx, %ecx
	movzwl	(%rax,%rcx,2), %edx
	movzwl	-12(%rbp), %r8d
	cmpl	%r8d, %edx
	jle	LBB0_4
## BB#3:                                ##   in Loop: Header=BB0_1 Depth=1
	movq	_blocks@GOTPCREL(%rip), %rax
	movq	(%rax), %rax
	movzwl	-10(%rbp), %ecx
	movl	%ecx, %edx
	movw	(%rax,%rdx,2), %si
	movw	%si, -12(%rbp)
	movw	-10(%rbp), %si
	movw	%si, -14(%rbp)
LBB0_4:                                 ##   in Loop: Header=BB0_1 Depth=1
	jmp	LBB0_5
LBB0_5:                                 ##   in Loop: Header=BB0_1 Depth=1
	movw	-10(%rbp), %ax
	addw	$1, %ax
	movw	%ax, -10(%rbp)
	jmp	LBB0_1
LBB0_6:
	movw	$0, -10(%rbp)
LBB0_7:                                 ## =>This Loop Header: Depth=1
                                        ##     Child Loop BB0_9 Depth 2
	movzwl	-10(%rbp), %eax
	movzwl	_steps(%rip), %ecx
	cmpl	%ecx, %eax
	jge	LBB0_18
## BB#8:                                ##   in Loop: Header=BB0_7 Depth=1
	movw	$0, -8(%rbp)
LBB0_9:                                 ##   Parent Loop BB0_7 Depth=1
                                        ## =>  This Inner Loop Header: Depth=2
	movq	_nblocks@GOTPCREL(%rip), %rax
	movzwl	-8(%rbp), %ecx
	movzwl	(%rax), %edx
	cmpl	%edx, %ecx
	jge	LBB0_14
## BB#10:                               ##   in Loop: Header=BB0_9 Depth=2
	movq	_nblocks@GOTPCREL(%rip), %rax
	movq	_history@GOTPCREL(%rip), %rcx
	movq	(%rcx), %rcx
	movzwl	-10(%rbp), %edx
	movzwl	(%rax), %esi
	imull	%esi, %edx
	movslq	%edx, %rax
	movq	(%rcx,%rax,8), %rax
	movzwl	-8(%rbp), %edx
	movl	%edx, %ecx
	movzwl	(%rax,%rcx,2), %edx
	movq	-24(%rbp), %rax
	movzwl	-8(%rbp), %esi
	movl	%esi, %ecx
	movzwl	(%rax,%rcx,2), %esi
	cmpl	%esi, %edx
	je	LBB0_12
## BB#11:                               ##   in Loop: Header=BB0_7 Depth=1
	jmp	LBB0_14
LBB0_12:                                ##   in Loop: Header=BB0_9 Depth=2
	jmp	LBB0_13
LBB0_13:                                ##   in Loop: Header=BB0_9 Depth=2
	movw	-8(%rbp), %ax
	addw	$1, %ax
	movw	%ax, -8(%rbp)
	jmp	LBB0_9
LBB0_14:                                ##   in Loop: Header=BB0_7 Depth=1
	movq	_nblocks@GOTPCREL(%rip), %rax
	movzwl	-8(%rbp), %ecx
	movzwl	(%rax), %edx
	cmpl	%edx, %ecx
	jne	LBB0_16
## BB#15:
	movzwl	-8(%rbp), %eax
	movl	%eax, -4(%rbp)
	jmp	LBB0_23
LBB0_16:                                ##   in Loop: Header=BB0_7 Depth=1
	jmp	LBB0_17
LBB0_17:                                ##   in Loop: Header=BB0_7 Depth=1
	movw	-10(%rbp), %ax
	addw	$1, %ax
	movw	%ax, -10(%rbp)
	jmp	LBB0_7
LBB0_18:
	movq	_blocks@GOTPCREL(%rip), %rax
	movq	(%rax), %rax
	movzwl	-14(%rbp), %ecx
	movl	%ecx, %edx
	movw	$0, (%rax,%rdx,2)
	movw	$1, -6(%rbp)
LBB0_19:                                ## =>This Inner Loop Header: Depth=1
	movzwl	-6(%rbp), %eax
	movzwl	-12(%rbp), %ecx
	cmpl	%ecx, %eax
	jg	LBB0_22
## BB#20:                               ##   in Loop: Header=BB0_19 Depth=1
	movq	_nblocks@GOTPCREL(%rip), %rax
	movq	_blocks@GOTPCREL(%rip), %rcx
	movq	(%rcx), %rcx
	movzwl	-6(%rbp), %edx
	movzwl	-14(%rbp), %esi
	addl	%esi, %edx
	movzwl	(%rax), %esi
	movl	%edx, %eax
	cltd
	idivl	%esi
	movslq	%edx, %rdi
	movw	(%rcx,%rdi,2), %r8w
	addw	$1, %r8w
	movw	%r8w, (%rcx,%rdi,2)
## BB#21:                               ##   in Loop: Header=BB0_19 Depth=1
	movw	-6(%rbp), %ax
	addw	$1, %ax
	movw	%ax, -6(%rbp)
	jmp	LBB0_19
LBB0_22:
	movw	_steps(%rip), %ax
	addw	$1, %ax
	movw	%ax, _steps(%rip)
	callq	_step
	movl	%eax, -4(%rbp)
LBB0_23:
	movl	-4(%rbp), %eax
	addq	$32, %rsp
	popq	%rbp
	retq
	.cfi_endproc

	.globl	_main
	.p2align	4, 0x90
_main:                                  ## @main
	.cfi_startproc
## BB#0:
	pushq	%rbp
Lcfi3:
	.cfi_def_cfa_offset 16
Lcfi4:
	.cfi_offset %rbp, -16
	movq	%rsp, %rbp
Lcfi5:
	.cfi_def_cfa_register %rbp
	subq	$32, %rsp
	movq	_nblocks@GOTPCREL(%rip), %rax
	movl	$0, -4(%rbp)
	movl	%edi, -8(%rbp)
	movq	%rsi, -16(%rbp)
	movl	-8(%rbp), %edi
	movw	%di, %cx
	movw	%cx, (%rax)
	movslq	-8(%rbp), %rax
	shlq	$1, %rax
	movq	%rax, %rdi
	callq	_malloc
	movq	_blocks@GOTPCREL(%rip), %rsi
	movq	%rax, (%rsi)
	movslq	-8(%rbp), %rax
	shlq	$1, %rax
	imulq	$20000, %rax, %rax      ## imm = 0x4E20
	imulq	$10, %rax, %rdi
	callq	_malloc
	movq	_history@GOTPCREL(%rip), %rsi
	movq	%rax, (%rsi)
	movw	$0, -18(%rbp)
	movw	$0, -18(%rbp)
LBB1_1:                                 ## =>This Inner Loop Header: Depth=1
	movzwl	-18(%rbp), %eax
	cmpl	-8(%rbp), %eax
	jge	LBB1_4
## BB#2:                                ##   in Loop: Header=BB1_1 Depth=1
	movq	-16(%rbp), %rax
	movzwl	-18(%rbp), %ecx
	movl	%ecx, %edx
	movq	(%rax,%rdx,8), %rdi
	callq	_atoi
	movq	_blocks@GOTPCREL(%rip), %rdx
	movw	%ax, %si
	movq	(%rdx), %rdx
	movzwl	-18(%rbp), %eax
	movl	%eax, %edi
	movw	%si, (%rdx,%rdi,2)
## BB#3:                                ##   in Loop: Header=BB1_1 Depth=1
	movw	-18(%rbp), %ax
	addw	$1, %ax
	movw	%ax, -18(%rbp)
	jmp	LBB1_1
LBB1_4:
	callq	_step
	leaq	L_.str(%rip), %rdi
	movl	%eax, -24(%rbp)
	movzwl	_steps(%rip), %esi
	movl	-24(%rbp), %edx
	movzwl	_steps(%rip), %eax
	subl	-24(%rbp), %eax
	movl	%eax, %ecx
	movb	$0, %al
	callq	_printf
	movl	-4(%rbp), %ecx
	movl	%eax, -28(%rbp)         ## 4-byte Spill
	movl	%ecx, %eax
	addq	$32, %rsp
	popq	%rbp
	retq
	.cfi_endproc

	.globl	_steps                  ## @steps
.zerofill __DATA,__common,_steps,2,1
	.comm	_history,8,3            ## @history
	.comm	_nblocks,2,1            ## @nblocks
	.comm	_blocks,8,3             ## @blocks
	.section	__TEXT,__cstring,cstring_literals
L_.str:                                 ## @.str
	.asciz	"steps: %d   found: %d   diff: %d"


.subsections_via_symbols
